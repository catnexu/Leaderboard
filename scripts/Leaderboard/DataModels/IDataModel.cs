namespace Leaderboard;

public interface IDataModel<out T>
{
    T Map();
}