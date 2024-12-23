using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Helper;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class LoginService : ILoginService
    {
        private IAuthRepository authRepository;
        private IManagerService managerService;

        public LoginService(IAuthRepository authRepository, IManagerService managerService)
        {
            this.authRepository = authRepository;
            this.managerService = managerService;
        }

        public ManagersEntity login(string email, string password)
        {
           LoginEntity user = authRepository.GetUser(email);
            if(user==null)
            {
                throw new CustomException("Invalid User");
            }
            bool isValid = PasswordHelper.VerifyPassword(password, user.Password);
            if(!isValid)
            {
                throw new CustomException("Invalid Login");
            }
            return managerService.GetManagerByEmail(email);
        }

        public Guid SignUp(ManagerRequest request)
        {
            var a = authRepository.GetUser(request.Email);
            if(a!=null)
            {
                throw new CustomException("User already exists");
            }
            LoginEntity entity = new LoginEntity
            {
                Email = request.Email,
                Password = PasswordHelper.HashPassword(request.Password),
                IsActive = true
            };            
            authRepository.AddUser(entity);
            ManagersEntity manager = managerService.addManager(request);
            return manager.Id;
        }
    }
}
