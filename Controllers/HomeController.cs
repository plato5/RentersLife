using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentersLife.Utilities;
using RentersLife.Core.ViewModels;
using System.Diagnostics;

namespace RentersLife.Controllers
{
    [AuthorizationCheck]
    public class HomeController : BaseController
    {       
        public IActionResult Index()
        {                     
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchResult(SearchViewModel searchParams)
        {
            if (searchParams == null)
            {
                return BadRequest(Json("No Data"));
            }

            var result = "TEST";

            return Json(new { Status = "success", Result = result });          
        }
    }
}
