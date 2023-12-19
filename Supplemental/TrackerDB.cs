using CourseTracker.Models;
using SQLite;

namespace CourseTracker.Supplemental;

public class TrackerDb
{
    private Connection _connection;
    private SQLiteAsyncConnection _db;

    #region SQLite setup
    public const string DatabaseFilename = "TrackerDB.db3";

    public const SQLiteOpenFlags Flags =
        // Create our SQLite DB if it doesn't exist
        SQLiteOpenFlags.Create |
        // Set multi-thread DB access for performance
        SQLiteOpenFlags.SharedCache |
        // We need to be able to read from and write to DB
        SQLiteOpenFlags.ReadWrite |
        // Configure data protection mode on the DB
        // Device must be unlocked for access
        SQLiteOpenFlags.ProtectionComplete;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    // This is the path to the database on the device and is used by the SQLiteConnection object
    // to connect to the database.

    public static string DatabasePathPlatform =>
        Path.Combine(FileSystem.CacheDirectory, DatabaseFilename);
    // This is the platform-specific path(?) to the database on the device and is used by the SQLiteConnection object
    // to connect to the database. It may also be just a cache directory, but I'm not sure.

    #endregion

    private async Task Initialize()
    {
        if (_db != null)
        {
            return;
        }

        _connection ??= new Connection();

        _db = _connection.GetAsyncConnection();
        await _db.EnableLoadExtensionAsync(true);
        await SetupTables(_db);
    }

    private static async Task SetupTables(SQLiteAsyncConnection db)
    {
        await db.CreateTableAsync<Term>();
        await db.CreateTableAsync<Course>();
        await db.CreateTableAsync<Assessment>();
        await db.CreateTableAsync<Instructor>();
    }

    #region Object Operations

    public async Task<List<Assessment>> GetAssessmentsAsync()
    {
        await Initialize();
        return await _db.Table<Assessment>().ToListAsync();
    }

    public async Task<List<Assessment>> GetAssessmentsByCourseIdAsync(string courseId)
    {
        await Initialize();
        return await _db.Table<Assessment>().Where(a => a.CourseId == courseId).ToListAsync();
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        await Initialize();
        return await _db.Table<Course>().ToListAsync();
    }

    public async Task<List<Course>> GetCoursesByTermIdAsync(string termId) //TODO: Should this be termName?
    {
        await Initialize();
        return await _db.Table<Course>().Where(c => c.TermId == termId).ToListAsync();
    }

    public async Task<List<Instructor>> GetInstructorsAsync()
    {
        await Initialize();
        return await _db.Table<Instructor>().ToListAsync();
    }

    public async Task<List<Instructor>> GetInstructorsByCourseIdAsync(string courseId)
    {
        await Initialize();
        return await _db.Table<Instructor>().Where(i => i.CourseId == courseId).ToListAsync();
    }

    public async Task<List<Term>> GetTermsAsync()
    {
        await Initialize();
        return await _db.Table<Term>().ToListAsync();
    }

    public async Task<Term> GetTermByIdAsync(string termId)
    {
        await Initialize();
        return await _db.Table<Term>().Where(t => t.TermId == termId).FirstOrDefaultAsync();
    }

    #endregion
}