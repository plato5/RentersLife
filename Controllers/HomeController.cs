using Microsoft.AspNetCore.Mvc;
using RentersLife.ViewModels;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    public class HomeController : BaseController
    {       
        public IActionResult Index()
        {           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
