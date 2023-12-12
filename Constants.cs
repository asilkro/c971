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

        public static async Task InitializeDatabaseAsync()
        {
            var asyncConnection = GetAsyncConnection();
            await asyncConnection.CreateTableAsync<Term>();
            await asyncConnection.CreateTableAsync<Course>();
            await asyncConnection.CreateTableAsync<Assessment>();
            await asyncConnection.CreateTableAsync<Instructor>();
        }

        #endregion

        #region Database connection

        public static SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(DatabasePath, Flags);
        }



        #endregion

        #region Utility methods

        #endregion
    }
}