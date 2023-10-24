using Microsoft.AspNetCore.Mvc;

namespace Technical_Assesment_Web.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
