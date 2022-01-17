using Microsoft.AspNetCore.Mvc;
using RentersLife.Core.Services;
using RentersLife.Utilities;
using RentersLife.ViewModels;
using System;

namespace RentersLife.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly string _controllerName;

        public RegisterController(IAccountService accountService)
        {
            _accountService = accountService;
            _controllerName = "Register";
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
                        var errorViewModel = SetErrorMessage("Invalid email/password try again.", _controllerName);
                        return RedirectToAction("Index", "Error", errorViewModel);
                    }

                    // set up a cache for user session                  
                    HttpContext.Session.Set<AccountViewModel>(HttpContext.Session.Id, loggedInAccount);
                }
                catch (InvalidOperationException ex)
                {
                    var errorViewModel = SetErrorMessage("Invalid email / password try again.", _controllerName);
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
     
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View("Error", errorViewModel);
        }
       
    }
}
