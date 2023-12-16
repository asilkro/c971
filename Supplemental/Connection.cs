using SQLite;

namespace CourseTracker.Supplemental;

interface IAsyncSqLite
{
    SQLiteAsyncConnection GetAsyncConnection();
}

interface ISqLite
{
    SQLiteConnection GetConnection();
}
public class Connection : IAsyncSqLite, ISqLite
{
    public SQLiteAsyncConnection GetAsyncConnection()
    {
        return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags); 
    }

    public SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
    }
}