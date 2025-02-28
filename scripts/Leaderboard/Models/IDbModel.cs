namespace Leaderboard;

public interface IDbModel<out T>
{
    T Map();
}