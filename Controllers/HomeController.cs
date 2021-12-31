using Microsoft.AspNetCore.Mvc;

namespace RentersLife.Controllers
{
    public class HomeController : Controller
    {       
        public IActionResult Index()
        {
            return View();
        }      
    }
}
