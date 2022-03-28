using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentersLife.Core.Services;
using RentersLife.Utilities;

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
            return View();
        }
    }
}
