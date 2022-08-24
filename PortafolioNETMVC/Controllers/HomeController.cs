using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortafolioNETMVC.Models;
using PortafolioNETMVC.Servicios;

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
        var reporsitorioProyectos = new RepositorioProyecto();
        var proyectos = reporsitorioProyectos.ObtenerProyectos().Take(3).ToList();
        var modelo = new HomeIndexViewModel() { Proyectos = proyectos};
        return View(modelo);
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