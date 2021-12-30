using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentersLife.ViewModels;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    public class RegisterController : Controller
    {      
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register([Bind("Password, Email")] AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Error", "Account");
            }

            return View(account);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
