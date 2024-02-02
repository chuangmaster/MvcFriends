using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcFriends.Models;

namespace MvcFriends.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _Env;

    [ViewData()]
    public string PageName { get; set; }

    [ViewData(Key = "Editor")]
    public string PageEditor { get; set; }

    [TempData(Key = "ErrorMessage")]
    public string ErrorMessage { get; set; }

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _Env = env;
        var eventId = new EventId((int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds(), "FriendsController Event Name");
        _logger.LogInformation(eventId, "Information: FriendsController init");
        PageName = typeof(HomeController).Assembly.FullName ?? string.Empty;
        PageEditor = "Zander";
    }

    public IActionResult Index()
    {
        ViewBag.Env = _Env.EnvironmentName;
        ViewData["ContentRootPath"] = _Env.ContentRootPath;

        //temp
        ErrorMessage = "Error message !";
        // TempData["ErrorMessage"] = "Error message !";

        return View();
    }

    public IActionResult Privacy()
    {
        TempData.Keep();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
