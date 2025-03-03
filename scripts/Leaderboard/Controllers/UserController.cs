using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leaderboard;

[ApiController]
[Route("api/[controller]")]
public sealed class UserController : ControllerBase
{
    private readonly UserDbContext _context;
    private readonly Logger _logger;

    public UserController(UserDbContext context,  Logger logger)
    {
        _context = context;
        _logger = logger;
    }
    
    [HttpGet("test")]
    public async Task<ActionResult<string>> Test()
    {
        return new ActionResult<string>("Hello");
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