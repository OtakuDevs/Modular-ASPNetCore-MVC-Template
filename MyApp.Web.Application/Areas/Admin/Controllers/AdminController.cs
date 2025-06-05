using Microsoft.AspNetCore.Mvc;

namespace ModularASPNetCoreMVCTemplate.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}