using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentersLife.Core.Services;
using RentersLife.Core.ViewModels;
using RentersLife.Utilities;
using System.Collections.Generic;

namespace RentersLife.Controllers
{
    [AuthorizationCheck]
    public class ManagerProfileController : BaseController
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IManagerProfileService _managerProfileService;

        public ManagerProfileController(ILogger<LoginController> logger, IManagerProfileService managerProfileService)
        {
            _logger = logger;
            _managerProfileService = managerProfileService;
        }
     
        public ActionResult Index()
        {
            var user = LoggedinUser.GetAccount(HttpContext);
            List<ManagerProfileViewModel> managerProfiles = new List<ManagerProfileViewModel>();

            if (user == null)
                throw new System.Exception("Session is invalid");

            managerProfiles = _managerProfileService.GetManagerProfiles(user.Id);
            return View(managerProfiles);
        }

        // GET: ManagerProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerProfileController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ManagerProfileController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
