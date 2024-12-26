using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KAMLMSBackend.Controllers
{
    [Route("api/central-data")]
    [ApiController]
    public class CentralDataController : ControllerBase
    {
        private ICallManagementService callManagerService;
        public CentralDataController(ICallManagementService callManagerService)
        {
            this.callManagerService = callManagerService;
        }
        [HttpGet("get-followups")]
        public IActionResult getFollowupCalls(string? day, string? month, string? year)
        {
            return Ok(callManagerService.GetFollowUpCallsList(day,month,year));
        }

        [HttpGet("at-risk")]
        public IActionResult atRisk()
        {
            return Ok(callManagerService.AtRisk());
        }
    }
}
