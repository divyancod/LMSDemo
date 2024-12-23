using KAMLMSContracts.RequestModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KAMLMSBackend.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class KManagersController : ControllerBase
    {
        private IManagerService service;
        public KManagersController(IManagerService service)
        {
            this.service = service;
        }
        // GET: api/<KManagersController>
        [HttpPost("add")]
        public IActionResult AddManager(ManagerRequest request)
        {
            return Ok(service.addManager(request));
        }
    }
}
