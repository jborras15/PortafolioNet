using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortafolioNETMVC.Models;

namespace PortafolioNETMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var persona = new Persona()
        {
            Nombre = "Jorge Borras",
            Edad = 28
        };
        return View(persona);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}