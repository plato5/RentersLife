using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentersLife.Utilities;
using RentersLife.Core.ViewModels;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    [AuthorizationCheck]
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

        public IActionResult Search()
        {
            return View();
        }
    }
}
