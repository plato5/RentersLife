using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentersLife.Core.Services;
using RentersLife.ViewModels;
using System;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IAccountService _accountService;

        public LoginController(ILogger<LoginController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel accountView)
        {
            AccountViewModel loggedInAccount = null;
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: set up a cache for this info
                    loggedInAccount = _accountService.ValidateAccount(accountView);
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
