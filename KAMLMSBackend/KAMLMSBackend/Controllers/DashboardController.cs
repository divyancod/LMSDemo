using KAMLMSContracts.ResponseModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private ICallManagementService _callManagementService;
        private ILeadsService _leadsService;
        public DashboardController(ICallManagementService callManagementService, ILeadsService leadsService)
        {
            _callManagementService = callManagementService;
            _leadsService = leadsService;
        }


        [HttpGet]
        public ActionResult<DashboardResponseWithType> GetLeadsDashboard()
        {
            try
            {
                var response = _leadsService.GetLeadDashboard();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("by-followups")]
        public ActionResult<IList<FollowUpResponse>> getFollowupForDashboard(string? day, string? month, string? year,int page, int take)
        {
            try
            {
                return Ok(_callManagementService.GetFollowUpCallsList(day, month, year,page, take));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("by-risk")]
        public ActionResult<IList<FollowUpResponse>> getAtRiskLeadsForDashboard(int page, int take)
        {
            try
            {
                return Ok(_callManagementService.AtRisk(page, take));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
