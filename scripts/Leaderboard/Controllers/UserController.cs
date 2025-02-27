using Microsoft.AspNetCore.Mvc;

namespace Leaderboard.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}