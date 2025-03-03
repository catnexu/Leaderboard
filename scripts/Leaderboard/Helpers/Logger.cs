namespace Leaderboard;

internal static class Logger
{
    public static void Log(string message)
    {
        Console.WriteLine($"{DateTime.Now} INFO: {message}");
    }

    public static void LogDebug(string message)
    {
        if (EnvironmentHelper.DevEnvironment)
        {
            Log(message);
        }
    }

    public static void LogError(string message, Exception ex)
    {
        string exMessage = ex.InnerException != null
            ? $"{ex.Message}: {ex.InnerException.Message}, {ex.StackTrace}"
            : $"{ex.Message}: {ex.StackTrace}";
        Console.WriteLine($"{DateTime.Now} ERROR: {message}, {exMessage}");
    }

    public static void LogError(Exception ex)
    {
        string exMessage = ex.InnerException != null
            ? $"{ex.Message}: {ex.InnerException.Message}, {ex.StackTrace}"
            : $"{ex.Message}: {ex.StackTrace}";
        Console.WriteLine($"{DateTime.Now} ERROR: {exMessage}");
    }
}