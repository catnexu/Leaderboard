namespace Leaderboard;

public sealed class SessionManager
{
    private readonly Dictionary<string, SessionInfo> _sessions;

    public SessionManager()
    {
        _sessions = new  Dictionary<string, SessionInfo>(5000);
    }
        
    public bool CreateOrUpdateSession(string playerId)
    {
        long currTime = DateTime.Now.Ticks;
        if (_sessions.TryGetValue(playerId, out SessionInfo info))
        {
            info.StartTime = currTime;
            return true;
        }
            
        return _sessions.TryAdd(playerId, new SessionInfo
        {
            StartTime = currTime,
        });
    }

    public bool HasSession(string playerId)
    {
        return _sessions.ContainsKey(playerId);
    }
        
    public bool CloseSession(string playerId)
    {
        return _sessions.Remove(playerId);
    }
}