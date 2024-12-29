using KAMLMSBackend.Authentication;
using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSService.Interfaces;
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
        /// <summary>
        /// Signup endpoint to enable user signup to access platform
        /// </summary>
        /// <param name="request">Email, password, fullname and phone required and to be passed as request</param>
        /// <returns>Signed up user unique GUID or else error message in case of error</returns>
        [HttpPost("signup")]
        public ActionResult<string> SignUp(ManagerRequest request)
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
        /// <summary>
        /// Login endpoint to accept login requred email and password
        /// </summary>
        /// <param name="request">email and password</param>
        /// <returns>Return login response with fullname positon email and login token.</returns>
        [HttpPost("login")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
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
