using Microsoft.AspNetCore.Mvc;
using RentersLife.ViewModels;

namespace RentersLife.Controllers
{
    public class BaseController : Controller
    {       
        protected ErrorViewModel SetErrorMessage(string message)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            errorViewModel.RegistationErrorMessage = message;

            return errorViewModel;
        }
    }
}
