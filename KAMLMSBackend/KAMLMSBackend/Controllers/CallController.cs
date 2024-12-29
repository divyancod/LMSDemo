using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
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
        public ActionResult createCall(CallScheduleRequest request)
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

        //[HttpGet]
        //public ActionResult GetCalls([FromQuery] string? companyId, [FromQuery] string? pocId, [FromQuery] int? status, [FromQuery] int page, [FromQuery] int pageSize)
        //{

        //    if(companyId==null && pocId==null)
        //    {
        //        return BadRequest("Either company id or poc id is required.");
        //    }
        //    return Ok();
        //}

        //[HttpGet("{id}")]
        //public ActionResult GetCallById(Guid id)
        //{
        //    return Ok();
        //}

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

        //[HttpGet("by-poc/{pocid}")]
        //public IActionResult getCallsByPocyId(string pocid)
        //{
        //    return Ok(callManagementService.GetAllCallScheduledByPOC(pocid));
        //}
    }
}
