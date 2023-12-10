using CourseTracker.Models;
using SQLite;
using System;

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

        #endregion

        #region Database connection
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(DatabasePath, Flags);
        }
        #endregion

        #region Utility methods
        public static async Task InitializeDatabaseAsync()
        {
            using var connection = GetConnection();
            await connection.CreateTableAsync<Instructor>();
            await connection.CreateTableAsync<Course>();
            await connection.CreateTableAsync<Term>();
            await connection.CreateTableAsync<Assessment>();
        }

        public static async Task CreateTableAsync<T>(this SQLiteConnection connection, bool forceCreateTable = false)
        {
            try
            {
                string createTableQuery = SQLite3-NetPipeStyleUriParser. SqlGenerator.CreateSqlTable(typeof(T));

                if (forceCreateTable || !await TableExistsAsync<T>(connection))
                {
                    // Create the table
                    await connection.ExecuteAsync(createTableQuery);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating table '{typeof(T).Name}'", ex);
            }
        }

        private static async Task<bool> TableExistsAsync<T>(this SQLiteConnection connection)
        {
            string tableName = SqlGenerator.GetTableName(typeof(T));
            string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";

            using (var statement = await connection.PrepareAsync(query))
            {
                return await statement.ReadAsync();
            }
        }

        #endregion
    }
}