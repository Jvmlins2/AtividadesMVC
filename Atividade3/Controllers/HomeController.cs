using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Atividade3.Models;

namespace Atividade3.Controllers;

public class HomeController : Controller
{
    private readonly AlimentoService _alimentoService;

    public HomeController(AlimentoService alimentoService)
    {
        _alimentoService = alimentoService;
    }

    public IActionResult Index()
    {
        var alimentos = _alimentoService.GetAllAlimentos();
        return View(alimentos);
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
