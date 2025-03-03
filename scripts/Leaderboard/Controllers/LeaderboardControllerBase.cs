using Microsoft.AspNetCore.Mvc;

namespace Leaderboard;

internal abstract class LeaderboardControllerBase : ControllerBase
{
    protected ActionResult ReturnSensitiveError(int statusCode, Exception ex)
    {
        if (EnvironmentHelper.DevEnvironment)
        {
            return StatusCode(statusCode, $"Error: {ex.Message}");
        }

        return StatusCode(statusCode);
    }
    
    protected ActionResult ReturnSensitiveError(int statusCode, string message)
    {
        if (EnvironmentHelper.DevEnvironment)
        {
            return StatusCode(statusCode, $"Error: {message}");
        }

        return StatusCode(statusCode);
    }
}