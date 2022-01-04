using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentersLife.Core.Services;
using RentersLife.ViewModels;
using System;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IAccountService _accountService;
        private readonly string _controllerName;

        public LoginController(ILogger<LoginController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
            _controllerName = "Login";
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
                       
                        var errorViewModel = SetErrorMessage("Invalid email/password try again.", _controllerName);
                        return RedirectToAction("Index", "Error", errorViewModel);
                    }

                    // TODO: set up a cache for this info
                   
                }
                catch (InvalidOperationException ex)
                {
                    var errorViewModel = SetErrorMessage(ex.Message, _controllerName);
                    return RedirectToAction("Index", "Error", errorViewModel);
                }
                catch (Exception ex)
                {
                    var errorViewModel = SetErrorMessage(ex.Message, _controllerName);
                    return RedirectToAction("Index", "Error", errorViewModel);
                }
            }
            else
            {
                var errorViewModel = SetErrorMessage("Invalid email/password try again.", _controllerName);
                return RedirectToAction("Index", "Error", errorViewModel);
            }

            return RedirectToAction("Index", "Home");
        }
           
    }
}
