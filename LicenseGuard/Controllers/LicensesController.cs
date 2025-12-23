using Microsoft.AspNetCore.Mvc;

namespace LicenseGuard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicensesController : ControllerBase
    {
        [HttpPost("validate")]
        public IActionResult ValidateLicense()
        {
            return Ok("License is valid.");
        }
    }
}
