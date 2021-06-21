using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kubehealth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        [Route("status/liveness/break")]
        public ActionResult NotHealthy()
        {
            HealthControl.IsLive = false;
            return Ok();
        }

        [HttpGet]
        [Route("status/liveness")]
        public ActionResult IsHealthy()
        {
            if (HealthControl.IsLive)
            {
                return Ok(HealthControl.IsLive);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("status/readiness/break")]
        public ActionResult NotReady()
        {
            HealthControl.IsReady = false;
            return Ok();
        }

        [HttpGet]
        [Route("status/readiness")]
        public ActionResult IsReady()
        {
            if (HealthControl.IsReady)
            {
                return Ok(HealthControl.IsReady);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("startup")]
        public ActionResult HasStarted()
        {
            return Ok();
        }
    }
}
