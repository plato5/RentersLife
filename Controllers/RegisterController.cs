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
                    // TODO: set up a cache for this info
                    var loggedInAccount = _accountService.CreateAccount(accountView);
                    if (loggedInAccount == null)
                    {
                        // Login failed -> pass back error state
                    }
                }
                catch (Exception ex)
                {
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
