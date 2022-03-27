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
        private readonly string _controllerName;

        public ManagerProfileController(ILogger<LoginController> logger, IManagerProfileService managerProfileService)
        {
            _logger = logger;
            _managerProfileService = managerProfileService;
            _controllerName = "ManagerProfile";
        }

        public IActionResult Index()
        {
            var user = LoggedinUser.GetAccount(HttpContext);
            List<ManagerProfileViewModel> managerProfiles = new List<ManagerProfileViewModel>();

            if (user == null)
                throw new System.Exception("Session is invalid");

            managerProfiles = _managerProfileService.GetManagerProfiles(user.Id);
            if (managerProfiles == null || managerProfiles.Count <= 0)
            {
                var errorViewModel = SetErrorMessage("There was a problem fetching your profile.", _controllerName);
                return RedirectToAction("Index", "Error", errorViewModel);
            }

            return View(managerProfiles);
        }


        public IActionResult Details(int id)
        {
            var user = LoggedinUser.GetAccount(HttpContext);
            ManagerProfileViewModel managerProfile = new ManagerProfileViewModel();

            if (user == null)
                throw new System.Exception("Session is invalid");

            managerProfile = _managerProfileService.GetManagerProfile(user.Id, id);
            if (managerProfile == null)
            {
                var errorViewModel = SetErrorMessage("There was a problem fetching your profile.", _controllerName);
                return RedirectToAction("Index", "Error", errorViewModel);
            }

            return View(managerProfile);
        }


        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = LoggedinUser.GetAccount(HttpContext);
            ManagerProfileViewModel managerProfile = new ManagerProfileViewModel();

            if (user == null)
                throw new System.Exception("Session is invalid");

            managerProfile = _managerProfileService.GetManagerProfile(user.Id, id);
            if (managerProfile == null)
            {
                var errorViewModel = SetErrorMessage("There was a problem fetching your profile.", _controllerName);
                return RedirectToAction("Index", "Error", errorViewModel);
            }

            return View(managerProfile);
        }

        public IActionResult Save(ManagerProfileViewModel profile)
        {
            try
            {
                var user = LoggedinUser.GetAccount(HttpContext);
                ManagerProfileViewModel managerProfile = new ManagerProfileViewModel();

                if (user == null)
                    throw new System.Exception("Session is invalid");

                if (profile.Id == 0)
                {
                    _managerProfileService.CreateManagerProfile(user.Id, profile);
                }
                else
                {
                    _managerProfileService.EditManagerProfile(user.Id, profile);
                }
             
            }
            catch
            {
                var errorViewModel = SetErrorMessage("There was a problem creating or updating your profile.", _controllerName);
                return RedirectToAction("Index", "Error", errorViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
