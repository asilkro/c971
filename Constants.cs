using CourseTracker.Models;
using CourseTracker.Supplemental;
using SQLite;


namespace CourseTracker
{
    public static class Constants
    {
        #region SQLite setup
        public const string DatabaseFilename = "CourseTrackerDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // Create our SQLite DB if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // Set multi-thread DB access for performance
            SQLite.SQLiteOpenFlags.SharedCache |
            // We need to be able to read from and write to DB
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Configure data protection mode on the DB
            // Device must be unlocked for access
            SQLite.SQLiteOpenFlags.ProtectionComplete;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        // This is the path to the database on the device and is used by the SQLiteConnection object
        // to connect to the database.
        
        public static string DatabasePathPlatform =>
            Path.Combine(FileSystem.CacheDirectory, DatabaseFilename);
        // This is the platform-specific path(?) to the database on the device and is used by the SQLiteConnection object
        // to connect to the database. It may also be just a cache directory, but I'm not sure.

        private static async Task InitializeDatabaseAsync()
        {
            var asyncConnection = new Connection();
            var db = asyncConnection.GetAsyncConnection();
            await SetupTables(db);
        }

        private static async Task SetupTables(SQLiteAsyncConnection db)
        {
            await db.CreateTableAsync<Term>();
            await db.CreateTableAsync<Course>();
            await db.CreateTableAsync<Assessment>();
            await db.CreateTableAsync<Instructor>();
        }

        #endregion

    }
}