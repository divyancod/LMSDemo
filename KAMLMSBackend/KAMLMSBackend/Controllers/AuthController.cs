using KAMLMSBackend.Authentication;
using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KAMLMSBackend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginService loginService;
        private JWTTokenHandler jWTTokenHandler;
        public AuthController(ILoginService loginService, JWTTokenHandler jWTTokenHandler)
        {
            this.loginService = loginService;
            this.jWTTokenHandler = jWTTokenHandler;
        }

        [HttpPost("signup")]
        public IActionResult SignUp(ManagerRequest request)
        {
            try
            {
                Guid id = loginService.SignUp(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                ManagersEntity user = loginService.login(request.Email, request.Password);
                LoginResponse response = new LoginResponse
                {
                    Name = user.FullName,
                    Position = user.Position,
                    Email = user.Email,
                    Token = jWTTokenHandler.GenerateToken(user.Email, user.Id)
                };
                return Ok(response);
        }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
    }
}
    }
}
