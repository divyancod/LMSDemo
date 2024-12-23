using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;

namespace KAMLMSService.Interfaces
{
    public interface ILoginService
    {
        Guid SignUp(ManagerRequest request);
        ManagersEntity login(string email, string password);
    }
}
