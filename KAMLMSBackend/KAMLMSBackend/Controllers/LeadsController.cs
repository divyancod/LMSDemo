﻿using KAMLMSBackend.Constants;
using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
    [Authorize]
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
        public ActionResult<LeadsEntity> Get(string leadId)
        {
            LeadsEntity resposne = leadsService.GetLead(new Guid(leadId));
            if (resposne == null)
            {
                return BadRequest("NOT FOUND");
            }
            return Ok(resposne);
        }

        [HttpPost]
        public ActionResult<Guid> AddLead(LeadsRequest request)
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
        public ActionResult updateLead(UpdateLead request)
        {
            leadsService.UpdateLeadStatus(request);
            return Ok();
        }

        [HttpGet("{leadType:int}")]
        public ActionResult<IList<LeadInfoResponse>> GetLeads(int leadType, [FromQuery] int page)
        {
            return Ok(leadsService.GetLeads(leadType, page, PAGE_DEFAULT));
        }

        [HttpGet("sync-lead")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult syncLeads()
        {
            leadsService.SyncLeadsToPlace();
            return Ok();
        }
    }
}
