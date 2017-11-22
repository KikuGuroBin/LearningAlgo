using SQLite.Net;
namespace LearningAlgo
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection(); // <-1

    }
}