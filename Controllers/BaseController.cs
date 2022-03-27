using Microsoft.AspNetCore.Mvc;
using RentersLife.Core.ViewModels;

namespace RentersLife.Controllers
{
    public class BaseController : Controller
    {       
        protected ErrorViewModel SetErrorMessage(string message, string controllerName)
        {            
            ErrorViewModel errorViewModel = new ErrorViewModel();

            if (!string.IsNullOrWhiteSpace(controllerName) && controllerName.Equals("Register"))
                errorViewModel.RegistationErrorMessage = message;
            else if (!string.IsNullOrWhiteSpace(controllerName) && controllerName.Equals("Login"))
                errorViewModel.LoginErrorMessage = message;
            else
                errorViewModel.ApplicationErrorMessage = message;

            return errorViewModel;
        }
    }
}
