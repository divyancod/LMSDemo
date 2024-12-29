//using KAMLMSContracts.RequestModels;
//using KAMLMSContracts.ResponseModels;
//using KAMLMSService.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace KAMLMSBackend.Controllers
//{
//    [Authorize]
//    [Route("api/call-details")]
//    [ApiController]
//    public class CallDetailsController : ControllerBase
//    {
//        private ICallManagementService callManagementService;
//        const int DEFAULT_TAKE = 10; // default page size 10 can be modified later.
//        public CallDetailsController(ICallManagementService callManagementService)
//        {
//            this.callManagementService = callManagementService;
//        }


//        [HttpPost("schedule")]
//        public IActionResult scheduleCall(CallScheduleRequest request)
//        {
//            try
//            {
//                return Ok(callManagementService.ScheduleCall(request, User.Identity.Name));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPost("calls-by-companyid")]
//        public ActionResult<IList<CallScheduledResponse>> getCallsByCompanyId([FromQuery] string companyId, [FromQuery] int page, [FromBody] CallFilters? filters)
//        {
//            return Ok(callManagementService.GettAllCallScheduledByCompany(companyId, page, DEFAULT_TAKE, filters));
//        }


//        [HttpGet("calls-by-pocid")]
//        public IActionResult getCallsByPocyId(string pocid)
//        {
//            return Ok(callManagementService.GetAllCallScheduledByPOC(pocid));
//        }


//        [HttpGet("calls-by-status")]
//        public IActionResult getCallsByPocyId(int status)
//        {
//            return Ok(callManagementService.GetAllCallScheduledByStatus(status));
//        }

//        [HttpGet("calls-status-types")]
//        public IActionResult getCallStatusTypes(int status)
//        {
//            return Ok(callManagementService.GetAllCallStatusDetails());
//        }

//        [HttpPost("update-call-status")]
//        public IActionResult updateCallStatus(UpdateCallScheduleRequest request)
//        {
//            try
//            {
//                callManagementService.UpdateCallStatus(request);
//                return Ok();
//            }
//            catch
//            {
//                return BadRequest("SOMETHING WENT WRONG");
//            }
//        }
//    }
//}
