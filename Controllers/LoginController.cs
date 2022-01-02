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
                    loggedInAccount = _accountService.Authenicate(accountView);
                    if (loggedInAccount == null)
                    {
                        var errorViewModel = SetErrorMessage("Login failed");
                        throw new ArgumentNullException(nameof(LoginViewModel));
                    }

                    // TODO: set up a cache for this info
                }
                catch (InvalidOperationException ex)
                {
                    var errorViewModel = SetErrorMessage(ex.Message);
                    return Error(errorViewModel);
                }
                catch (Exception ex)
                {
                    var errorViewModel = SetErrorMessage(ex.Message);
                    return Error(errorViewModel);
                }
            }
            else
            {
                var errorViewModel = SetErrorMessage("Invalid model passed in.");
                return RedirectToAction("Error", "Register", new { errorViewModel });
            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View("Error", errorViewModel);
        }

        private ErrorViewModel SetErrorMessage(string message)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            errorViewModel.ErrorMessage = message;

            return errorViewModel;
        }
    }
}
