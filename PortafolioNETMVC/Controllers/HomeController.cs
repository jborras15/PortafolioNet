using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using PortafolioNETMVC.Models;
using PortafolioNETMVC.Servicios;

namespace PortafolioNETMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyecto _repositorioProyecto;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger,
        IRepositorioProyecto repositorioProyecto,
        IConfiguration configuration)
    {
        _logger = logger;
        _repositorioProyecto = repositorioProyecto;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        var apellido = _configuration.GetValue<string>("Apellido");
        _logger.LogInformation("Este es un mensaje de log");
        _logger.LogCritical("Este es un mensaje de log");
        _logger.LogError("Este es un mensaje de log");
        _logger.LogWarning("Este es un mensaje de log " + apellido);
        _logger.LogDebug("Este es un mensaje de log");
        _logger.LogTrace("Este es un mensaje de log " );

        var proyectos = _repositorioProyecto.ObtenerProyectos().Take(3).ToList();
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