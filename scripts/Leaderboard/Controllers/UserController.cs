using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Leaderboard;

[ApiController]
[Route("api/[controller]")]
internal sealed class UserController : LeaderboardControllerBase
{
    private readonly UserDbContext _context;
    private readonly SessionManager _sessionManager;

    public UserController(UserDbContext context, SessionManager sessionManager)
    {
        _context = context;
        _sessionManager = sessionManager;
    }
    

    [HttpGet("getUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var result = await _context.Users.Select(x => x.Map()).ToListAsync();
        return Ok(result);
    }

    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser([FromBody] UserModel model)
    {
        if (string.IsNullOrEmpty(model.Id))
        {
            return BadRequest("Incorrect user");
        }

        try
        {
            var user = model.Map();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }

    [HttpPost("editUser")]
    public async Task<IActionResult> EditUser([FromBody] UserModel model)
    {
        await _context.Users.Where(x => x.Id == model.Id).ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, model.Name));
        return Ok(model);
    }


    [HttpDelete("deleteUser")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        await _context.Users.Where(x => x.Id == userId).ExecuteDeleteAsync();
        return Ok(true);
    }
}
