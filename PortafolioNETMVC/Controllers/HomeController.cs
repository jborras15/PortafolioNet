﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortafolioNETMVC.Models;
using PortafolioNETMVC.Servicios;

namespace PortafolioNETMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyecto _repositorioProyecto;
    public HomeController(ILogger<HomeController> logger, IRepositorioProyecto repositorioProyecto)
    {
        _logger = logger;
        _repositorioProyecto = repositorioProyecto;
    }

    public IActionResult Index()
    {
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