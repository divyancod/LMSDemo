using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;

namespace KAMLMSRepository.Repositories
{

    public class ManagerRepository : BaseRepository, IManagerRepository
    {
        public ManagerRepository(DatabaseContext context) : base(context)
        {
        }

        public ManagersEntity AddManager(ManagersEntity entity)
        {
            databaseContext.ManagersEntity.Add(entity);
            databaseContext.SaveChanges();
            return entity;
        }

        public IList<ManagersEntity> GetAllManagers()
        {
            return databaseContext.ManagersEntity.ToList();
        }

        public ManagersEntity GetManager(Guid id)
        {
            return databaseContext.ManagersEntity.FirstOrDefault(i => i.Id == id);
        }

        public ManagersEntity GetManagerByEmail(string email)
        {
            return databaseContext.ManagersEntity.FirstOrDefault(i => i.Email == email);
        }
    }
}
