using Microsoft.AspNetCore.Mvc;

namespace Dogshouseservice.API.Controllers
{
    [ApiController]
    [Route("api/ping")]
    [ApiVersion("0.1")]
    [ApiVersion("0.2")]
    [ApiVersion("0.3")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping(ApiVersion apiVersion)
        {
            return Ok($"Dogshouseservice.Version1.{apiVersion}");
        }
    }
}
