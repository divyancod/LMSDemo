using KAMLMSContracts.Entities;

namespace KAMLMSRepository.Interfaces
{
    public interface IManagerRepository
    {
        ManagersEntity AddManager(ManagersEntity entity);
        ManagersEntity GetManager(Guid id);
        IList<ManagersEntity> GetAllManagers();
        ManagersEntity GetManagerByEmail(string email);
    }
}
