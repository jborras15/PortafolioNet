using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using PortafolioNETMVC.Models;
using PortafolioNETMVC.Servicios;

namespace PortafolioNETMVC.Controllers;

public class HomeController : Controller
{
    private readonly IRepositorioProyecto _repositorioProyecto;
    

    public HomeController(
        IRepositorioProyecto repositorioProyecto)
    {
        _repositorioProyecto = repositorioProyecto;
        
    }

    public IActionResult Index()
    {
        var proyectos = _repositorioProyecto.ObtenerProyectos().Take(3).ToList();
        var modelo = new HomeIndexViewModel() { Proyectos = proyectos};
        return View(modelo);
    }

    public IActionResult Proyectos()
    {
        var proyectos = _repositorioProyecto.ObtenerProyectos();
        return View(proyectos);
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Contacto()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contacto(ContactoViewModel contactoViewModel)
    {
        return RedirectToAction("Gracias");
    }

    public IActionResult Gracias()
    {
        return View();
    }
}