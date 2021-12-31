using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentersLife.Core.Services;
using RentersLife.ViewModels;
using System;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAccountService _accountService;

        public RegisterController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register(RegistrationViewModel accountView)
        {
            if (ModelState.IsValid)
            {
               try
                {                   
                    var loggedInAccount = _accountService.Register(accountView);
                    if (loggedInAccount == null)
                    {                        
                        throw new ArgumentNullException(nameof(RegistrationViewModel));
                    }

                    // TODO: set up a cache for this info
                }
                catch (Exception ex)
                {
                    // TODO: set up custom error page for registration failure
                    return Error();
                }
            }
            else
            {
                return Error();
            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
