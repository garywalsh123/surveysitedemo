using Microsoft.AspNetCore.Mvc;

namespace SurveySite.Controllers
{
    [Route("api/health-check")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {

        public HealthCheckController()
        {
        }

        /// <summary>
        /// Make a call to check that the API is running
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CheckApi()
        {
            return new OkResult();
        }

    }
}
