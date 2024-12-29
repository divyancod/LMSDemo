using KAMLMSContracts.RequestModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KAMLMSBackend.Controllers
{
    [Authorize]
    [Route("api/point-of-contact")]
    [ApiController]
    public class PointOfContactController : ControllerBase
    {
        private IContactsManagementService contactsManagementService;
        public PointOfContactController(IContactsManagementService service)
        {
            contactsManagementService = service;
        }


        [HttpPost]
        public IActionResult addPOC(POCRequest request)
        {
            try
            {
                contactsManagementService.AddPOC(request,User.Identity.Name);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet("{companyId}")]
        public IActionResult getPOCs(string companyId, bool withLessData = false)
        {
            if(withLessData)
            {
                return Ok(contactsManagementService.getPocMin(companyId));
            }
            return Ok(contactsManagementService.getPOC(new Guid(companyId)));
        }
    }
}
