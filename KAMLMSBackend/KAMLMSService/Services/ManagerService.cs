using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class ManagerService : IManagerService
    {
        private IManagerRepository repository;
        public ManagerService(IManagerRepository repository)
        {
            this.repository = repository;
        }
        public ManagersEntity addManager(ManagerRequest request)
        {
            ManagersEntity entity = new ManagersEntity
            {
                Email = request.Email,
                FullName = request.FullName,
                Phone = request.Phone,
                Position = "Account Manager",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            entity = repository.AddManager(entity);
            return entity;
        }

        public ManagersEntity GetManagerByEmail(string email)
        {
            return repository.GetManagerByEmail(email);
        }
    }
}
