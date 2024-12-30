using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
    [Authorize]
    [Route("api/calls")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private ICallManagementService callManagementService;
        const int DEFAULT_TAKE = 10; // default page size 10 can be modified later.
        public CallController(ICallManagementService callManagementService)
        {
            this.callManagementService = callManagementService;
        }

        [HttpPost]
        public ActionResult<int> createCall(CallScheduleRequest request)
        {
            try
            {
                return Ok(callManagementService.ScheduleCall(request, User.Identity.Name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult updateCallStatus(UpdateCallScheduleRequest request)
        {
            try
            {
                callManagementService.UpdateCallStatus(request);
                return Ok();
            }
            catch
            {
                return BadRequest("SOMETHING WENT WRONG");
            }
        }

        [HttpGet("{companyId}")]
        public ActionResult<IList<CallScheduledResponse>> getCallsByCompanyId(string companyId, [FromQuery] int page, [FromQuery] List<int>? statuses = null)
        {
            CallFilters filters = new CallFilters { statusList = statuses };
            return Ok(callManagementService.GettAllCallScheduledByCompany(companyId, page, DEFAULT_TAKE, filters));
        }
    }
}
