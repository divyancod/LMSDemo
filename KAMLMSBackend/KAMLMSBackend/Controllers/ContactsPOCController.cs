using KAMLMSContracts.RequestModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KAMLMSBackend.Controllers
{
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
                contactsManagementService.AddPOC(request);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
