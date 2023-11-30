using System;
using System.IO;
using Microsoft.Maui.Storage;

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

        public static string DatabasePath_Platform =>
            Path.Combine(FileSystem.CacheDirectory, DatabaseFilename);
        #endregion

    }
}