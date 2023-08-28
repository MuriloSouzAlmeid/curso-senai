using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gamer_fullstack.Models;

namespace gamer_fullstack.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //Tras os dados do usuario
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }

    public IActionResult Privacy()
    {
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
