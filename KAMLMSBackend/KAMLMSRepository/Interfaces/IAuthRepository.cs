using KAMLMSContracts.Entities;

namespace KAMLMSRepository.Interfaces
{
    public interface IAuthRepository
    {
        void AddUser(LoginEntity entity);
        LoginEntity GetUser(string email);
    }
}
