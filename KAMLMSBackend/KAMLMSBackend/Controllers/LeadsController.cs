using KAMLMSBackend.Constants;
using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
    [Route("api/leads")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private ILeadsService leadsService;
        private const int PAGE_DEFAULT = 15;

        public LeadsController(ILeadsService leadsService)
        {
            this.leadsService = leadsService;
        }

        [HttpGet("{leadId:guid}")]
        public IActionResult Get(string leadId)
        {
            LeadsEntity resposne = leadsService.GetLead(new Guid(leadId));
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

        [HttpPatch]
        public IActionResult updateLead(UpdateLead request)
        {
            leadsService.UpdateLeadStatus(request);
            return Ok();
        }

        [HttpGet("{leadType:int}")]
        public IActionResult GetLeads(int leadType, [FromQuery] int page)
        {
            return Ok(leadsService.GetLeads(leadType, page, PAGE_DEFAULT));
        }
    }
}
