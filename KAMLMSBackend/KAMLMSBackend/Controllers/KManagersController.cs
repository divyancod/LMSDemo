using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Mvc;


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

        [HttpPost("add")]
        public ActionResult<ManagersEntity> AddManager(ManagerRequest request)
        {
            return Ok(service.addManager(request));
        }
    }
}
