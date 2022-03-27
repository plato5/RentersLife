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

        public IActionResult Index()
        {
            var user = LoggedinUser.GetAccount(HttpContext);
            List<ManagerProfileViewModel> managerProfiles = new List<ManagerProfileViewModel>();

            if (user == null)
                throw new System.Exception("Session is invalid");

            managerProfiles = _managerProfileService.GetManagerProfiles(user.Id);
            return View(managerProfiles);
        }


        public IActionResult Details(int id)
        {
            var user = LoggedinUser.GetAccount(HttpContext);
            ManagerProfileViewModel managerProfile = new ManagerProfileViewModel();

            if (user == null)
                throw new System.Exception("Session is invalid");

            managerProfile = _managerProfileService.GetManagerProfile(user.Id, id);

            return View(managerProfile);
        }


        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            // TODO: Get ManagerProfile by id
            return View();
        }

        public IActionResult Save(ManagerProfileViewModel profile)
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

    }
}
