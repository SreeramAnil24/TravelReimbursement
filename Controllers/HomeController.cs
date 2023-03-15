using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmpManage.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace EmpManage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // [HttpPost]
    // public async Task<IActionResult> UploadFile(IFormFile file)
    // {
    //     if (file != null && file.Length > 0)
    //     {
    //         string fileName = Path.GetFileName(file.FileName);
    //         string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(("~/Uploads"), fileName));
    //         using (var stream = new FileStream(path, FileMode.Create))
    //         {
    //             await file.CopyToAsync(stream);
    //         }

    //         // Save the file information to the database or a file
    //         // ...

    //         return RedirectToAction("Index");
    //     }

    //     return View();
    // }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Details()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
