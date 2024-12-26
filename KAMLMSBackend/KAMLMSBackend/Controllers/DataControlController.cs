using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KAMLMSBackend.Controllers
{
    [Route("api/data-control")]
    [ApiController]
    public class DataControlController : ControllerBase
    {
        private IDataControlService service;

        public DataControlController(IDataControlService dataControl)
        {
            service = dataControl;
        }

        [HttpGet("roles")]
        public IActionResult getRoles()
        {
            return Ok(service.getAllRoles());
        }

        [HttpGet("countries")]
        public IActionResult getAllCountries()
        {
            return Ok(service.getAllCountries());
        }
    }
}
