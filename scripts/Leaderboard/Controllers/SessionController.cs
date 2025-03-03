using Microsoft.AspNetCore.Mvc;

namespace Leaderboard;

[ApiController]
[Route("api/[controller]")]
public sealed class SessionController(SessionManager manager) : LeaderboardControllerBase
{
    [HttpPost]
    [Route("start")]
    public async Task<ActionResult> StartSession()
    {
        try
        {
            SessionStartRequest? dtoModel = await ContentBodyHelper.Read<SessionStartRequest>(Request);
            if (dtoModel == null)
            {
                Logger.Log($"SessionStart wrongRequest");
                Logger.LogDebug($"SessionStart request model is NULL");
                return ReturnSensitiveError(StatusCodes.Status400BadRequest, "Request is NULL");
            }

            if (string.IsNullOrWhiteSpace(dtoModel.UserId))
            {
                Logger.Log($"SessionStart wrongRequest");
                Logger.LogDebug($"SessionStart request model's PlayerId field is NULL or empty");
                return ReturnSensitiveError(StatusCodes.Status400BadRequest, "Invalid request content");
            }

            if (manager.CreateOrUpdateSession(dtoModel.UserId))
            {
                Logger.Log($"Session created for {dtoModel.UserId}");
                return Ok();
            }

            Logger.LogDebug("Session already open");
            return ReturnSensitiveError(StatusCodes.Status405MethodNotAllowed, "Session already open");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            return ReturnSensitiveError(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }

    [HttpPost]
    [Route("stop")]
    public async Task<IActionResult> CloseSession()
    {
        try
        {
            SessionCloseRequest? dtoModel = await ContentBodyHelper.Read<SessionCloseRequest>(Request);

            if (dtoModel == null)
            {
                Logger.Log($"SessionClose wrongRequest");
                Logger.LogDebug($"SessionClose request model is NULL");
                return ReturnSensitiveError(StatusCodes.Status400BadRequest, "Request is NULL");
            }

            if (manager.CloseSession(dtoModel.UserId))
            {
                Logger.Log($"Closing session for {dtoModel.UserId}");
                return Ok();
            }

            string errorStr = "No session with such id";
            Logger.Log(errorStr);
            return ReturnSensitiveError(StatusCodes.Status405MethodNotAllowed, errorStr);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            return ReturnSensitiveError(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }
}