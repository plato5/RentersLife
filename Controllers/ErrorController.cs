using Microsoft.AspNetCore.Mvc;
using RentersLife.Core.ViewModels;

namespace RentersLife.Controllers
{
    public class ErrorController : BaseController
    {       
        public IActionResult Index(ErrorViewModel ErrorView)
        {         
            return View(ErrorView);
        }
    }
}
