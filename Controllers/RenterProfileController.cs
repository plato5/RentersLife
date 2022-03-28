using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentersLife.Core.Services;
using RentersLife.Core.ViewModels;
using RentersLife.Utilities;
using System.Collections.Generic;

namespace RentersLife.Controllers
{
    [AuthorizationCheck]
    public class RenterProfileController : BaseController
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IRenterProfileService _renterProfileService;
        private readonly string _controllerName;

        public RenterProfileController(ILogger<LoginController> logger, IRenterProfileService renterProfileService)
        {
            _logger = logger;
            _renterProfileService = renterProfileService;
            _controllerName = "RenterProfile";
        }

        public IActionResult Index()
        {
            var user = LoggedinUser.GetAccount(HttpContext);
            List<RenterProfileViewModel> renterProfiles = new List<RenterProfileViewModel>();

            if (user == null)
                throw new System.Exception("Session is invalid");

            renterProfiles = _renterProfileService.GetRenterProfiles(user.Id);          

            return View(renterProfiles);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Save(RenterProfileViewModel profile)
        {
            try
            {
                var user = LoggedinUser.GetAccount(HttpContext);               

                if (user == null)
                    throw new System.Exception("Session is invalid");

                if (profile.Id == 0)
                {
                    profile.AccountId = user.Id;
                    _renterProfileService.CreateRenterProfile(user.Id, profile);
                }
                else
                {
                  //  _managerProfileService.EditManagerProfile(user.Id, profile);
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
