using KAMLMSContracts.RequestModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KAMLMSBackend.Controllers
{
    [Authorize]
    [Route("api/contacts-poc")]
    [ApiController]
    public class ContactsPOCController : ControllerBase
    {
        private IContactsManagementService contactsManagementService;
        public ContactsPOCController(IContactsManagementService service)
        {
            contactsManagementService = service;
        }


        [HttpPost("add")]
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

        [HttpGet("get-poc")]
        public IActionResult getPOCs(string companyId)
        {
            return Ok(contactsManagementService.getPOC(new Guid(companyId)));
        }

        [HttpGet("get-poc-min")]
        public IActionResult getPocsMin(string companyId)
        {
            return Ok(contactsManagementService.getPocMin(companyId));
        }
    }
}
