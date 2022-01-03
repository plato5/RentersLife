using Microsoft.AspNetCore.Mvc;
using RentersLife.Core.Services;
using RentersLife.ViewModels;
using System;

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
                        var errorViewModel = SetErrorMessage("Invalid email/password try again.");
                        return RedirectToAction("Index", "Error", errorViewModel);
                    }

                    // TODO: set up a cache for this info
                }
                catch (InvalidOperationException ex)
                {
                    var errorViewModel = SetErrorMessage("Invalid email / password try again.");
                      return RedirectToAction("Index", "Error", errorViewModel);
                }
                catch (Exception ex)
                {
                    var errorViewModel = SetErrorMessage(ex.Message);
                    return RedirectToAction("Index", "Error", errorViewModel);
                }
            }
            else
            {
                var errorViewModel = SetErrorMessage("Invalid email/password try again.");
                return RedirectToAction("Index", "Error", errorViewModel);
            }

            return RedirectToAction("Index", "Home");
        }
     
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View("Error", errorViewModel);
        }

        private ErrorViewModel SetErrorMessage(string message)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            errorViewModel.RegistationErrorMessage = message;

            return errorViewModel;
        }
    }
}
