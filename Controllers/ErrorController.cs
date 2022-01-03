using Microsoft.AspNetCore.Mvc;
using RentersLife.ViewModels;

namespace RentersLife.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(ErrorViewModel ErrorView)
        {         
            return View(ErrorView);
        }
    }
}
