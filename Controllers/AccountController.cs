using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentersLife.ViewModels;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    public class AccountController : Controller
    {      
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register([Bind("UserName, Password, Email")] AccountViewModel profile)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Error", "Account");
            }

            return View(profile);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
