using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;


namespace KAMLMSRepository.Repositories
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(DatabaseContext context) : base(context)
        {
        }

        public void AddUser(LoginEntity entity)
        {
            databaseContext.LoginEntities.Add(entity);
            databaseContext.SaveChanges();
        }

        public LoginEntity GetUser(string email)
        {
            return databaseContext.LoginEntities.FirstOrDefault(e=>e.Email == email);
        }
    }
}
