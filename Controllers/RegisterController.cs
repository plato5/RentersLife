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
