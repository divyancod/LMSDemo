using KAMLMSContracts.RequestModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
    [Authorize]
    [Route("api/call-details")]
    [ApiController]
    public class CallDetailsController : ControllerBase
    {
        private ICallManagementService callManagementService;
        public CallDetailsController(ICallManagementService callManagementService)
        {
            this.callManagementService = callManagementService;
        }

        [HttpPost("schedule")]
        public IActionResult scheduleCall(CallScheduleRequest request)
        {
            try
            {
                return Ok(callManagementService.ScheduleCall(request,User.Identity.Name));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("calls-by-companyid")]
        public IActionResult getCallsByCompanyId(string companyId)
        {
            return Ok(callManagementService.GettAllCallScheduledByCompany(companyId));
        }


        [HttpGet("calls-by-pocid")]
        public IActionResult getCallsByPocyId(string pocid)
        {
            return Ok(callManagementService.GetAllCallScheduledByPOC(pocid));
        }


        [HttpGet("calls-by-status")]
        public IActionResult getCallsByPocyId(int status)
        {
            return Ok(callManagementService.GetAllCallScheduledByStatus(status));
        }

        [HttpGet("calls-status-types")]
        public IActionResult getCallStatusTypes(int status)
        {
            return Ok(callManagementService.GetAllCallStatusDetails());
        }
    }
}
