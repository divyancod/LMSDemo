using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;

namespace KAMLMSService.Interfaces
{
    public interface IManagerService
    {
        ManagersEntity addManager(ManagerRequest manager);
        ManagersEntity GetManagerByEmail(string email);
    }
}
