using KAMLMSContracts.Entities;
using KAMLMSService.Interfaces;
using KAMLMSService.Services;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
    [Route("api/reference-data")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private IDataControlService _dataControlService;
        private ICallManagementService _callManagementService;
        private ILeadsService _leadService;

        public ReferenceDataController(IDataControlService dataControl, ICallManagementService callManagementService, ILeadsService leadsService)
        {
            _dataControlService = dataControl;
            _callManagementService = callManagementService;
            _leadService = leadsService;
        }

        [HttpGet("roles")]
        public ActionResult<IList<RolesEntity>> getRoles()
        {
            return Ok(_dataControlService.getAllRoles());
        }

        [HttpGet("countries")]
        public ActionResult<IList<CountryEntity>> getAllCountries()
        {
            return Ok(_dataControlService.getAllCountries());
        }

        [HttpGet("calls-status-types")]
        public ActionResult<IList<CallStatusEntity>> getCallStatusTypes(int status)
        {
            return Ok(_callManagementService.GetAllCallStatusDetails());
        }

        [HttpGet("lead-types")]
        public ActionResult<IList<LeadStatusEntity>> GetLeadTypes()
        {
            return Ok(_leadService.GetLeadTypes());
        }
    }
}
