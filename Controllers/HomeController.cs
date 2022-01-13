using Microsoft.AspNetCore.Mvc;
using RentersLife.Utilities;
using RentersLife.ViewModels;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    public class HomeController : BaseController
    {       
        public IActionResult Index()
        {          
            var user = HttpContext.Session.Get<AccountViewModel>(HttpContext.Session.Id);
            System.Console.WriteLine("test");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
