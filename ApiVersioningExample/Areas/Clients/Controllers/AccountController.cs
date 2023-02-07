using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningExample.Areas.Clients.Controllers
{
    [Area("Clients")]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok("Version 1");
    }

    [Area("Clients")]
    [ApiVersion(2.0)]
    [ControllerName("Account")]
    public class Account2Controller : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok("Version 2");
    }
}
