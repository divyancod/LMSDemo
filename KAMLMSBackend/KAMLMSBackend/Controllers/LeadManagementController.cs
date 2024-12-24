using KAMLMSBackend.Constants;
using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
    [Authorize]
    [Route("api/leads")]
    [ApiController]
    public class LeadManagementController : ControllerBase
    {
        private ILeadsService leadsService;

        public LeadManagementController(ILeadsService leadsService)
        {
            this.leadsService = leadsService;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            LeadsEntity resposne = leadsService.GetLead(id);
            if (resposne == null)
            {
                return BadRequest("NOT FOUND");
            }
            return Ok(resposne);
        }

        [HttpPost]
        public IActionResult AddLead(LeadsRequest request)
        {
            Guid id;
            try
            {
                id = leadsService.AddLeads(request, new Guid(User.Identity.Name));
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest(ErrorsConstants.ERROR_WRONG);
            }
            return Ok(id);
        }

        [HttpGet("get-leads-types")]
        public IActionResult GetLeadTypes()
        {
            return Ok(leadsService.GetLeadTypes());
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            var a = User.Identity.Name;
            return Ok("OK");
        }

        [HttpGet("lead-dashboard")]
        public IActionResult GetLeadsDashboard()
        {
            var response = leadsService.GetLeadDashboard();
            return Ok(response);
        }
    }
}
