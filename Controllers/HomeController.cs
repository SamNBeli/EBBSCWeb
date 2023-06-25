using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EBBSCweb.Models;
using EBBSCweb.Data;
using Microsoft.EntityFrameworkCore;

namespace EBBSCweb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    //GET:HomePage
    public async Task<IActionResult> Index()
    {
        var objMediaList = _context.Medias;
        return objMediaList != null ? View(await objMediaList.ToListAsync()) : Problem("Entity 'Media' is null ");
    }

    //GET:AboutPage
    public IActionResult About()
    {
        return View();
    }

    //GET:OrganigrammePage
    public IActionResult Organigramme()
    {
        return View();
    }

    //GET:MinisterePage
    public IActionResult Ministere()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}

