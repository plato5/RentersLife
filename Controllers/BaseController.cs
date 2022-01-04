using Microsoft.AspNetCore.Mvc;
using RentersLife.ViewModels;

namespace RentersLife.Controllers
{
    public class BaseController : Controller
    {       
        protected ErrorViewModel SetErrorMessage(string message, string controllerName)
        {            
            ErrorViewModel errorViewModel = new ErrorViewModel();

            if (controllerName.Equals("Register"))
                errorViewModel.RegistationErrorMessage = message;
            else
                errorViewModel.LoginErrorMessage = message;

            return errorViewModel;
        }
    }
}
