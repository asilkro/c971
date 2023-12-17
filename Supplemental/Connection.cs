using SQLite;

namespace CourseTracker.Supplemental;

interface IAsyncSqLite
{
    SQLiteAsyncConnection GetAsyncConnection();
}

public class Connection : IAsyncSqLite
{
    public SQLiteAsyncConnection GetAsyncConnection()
    {
        return new SQLiteAsyncConnection(TrackerDb.DatabasePath, TrackerDb.Flags);
    }
}