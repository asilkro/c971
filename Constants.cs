using CourseTracker.Models;
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
            // Set multi-threaded DB access for performance
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
            var asyncConnection = GetAsyncConnection();
            await SetupTables(asyncConnection);
        }

        private static async Task SetupTables(SQLiteAsyncConnection connection)
        {
            await connection.CreateTableAsync<Term>();
            await connection.CreateTableAsync<Course>();
            await connection.CreateTableAsync<Assessment>();
            await connection.CreateTableAsync<Instructor>();
        }

        #endregion

        #region Database connection

        public static SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(DatabasePath, Flags);
        }

        //TODO: Do I need an interface for this or can I just use the method above?
        public interface ISqLiteDb
        {
            SQLiteAsyncConnection GetAsyncConnection();
        }

        #endregion

        #region Utility methods

        //TODO: Do I need anything here?

        #endregion
    }
}