namespace Leaderboard;

public static class EnvironmentHelper
{
    public static bool DevEnvironment { get; private set; }
    
    static EnvironmentHelper()
    {
        DevEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "DEVELOPMENT";
    }
}