using KAMLMSContracts.Entities;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KAMLMSRepository.Repositories
{
    public class ContactRepository : BaseRepository, IContanctRepository
    {
        public ContactRepository(DatabaseContext context) : base(context)
        {
        }

        public ContactEntity addContact(ContactEntity entity)
        {
            databaseContext.ContactEntity.Add(entity);
            databaseContext.SaveChanges();
            return entity;
        }

        public int addCustomRole(string customRole)
        {
            CustomRoleEntity entity = new CustomRoleEntity
            {
                Name = customRole
            };
            databaseContext.CustomRoleEntity.Add(entity);
            databaseContext.SaveChanges();
            return entity.Id;
        }

        public IList<RolesEntity> getAllRoles()
        {
            return databaseContext.RolesEntity.ToList();
        }

        public IList<ContactEntity> GetPOC(Guid companyId)
        {
            return databaseContext.ContactEntity.Include(x=>x.Role).Include(x=>x.CustomRole).Where(x => x.LeadsId == companyId).ToList();
        }

        public IList<PocMinResponse> getPocMin(Guid CompanyId)
        {
            return databaseContext.ContactEntity.Where(x=>x.LeadsId == CompanyId).Select(x => new
            PocMinResponse{
                Id = x.Id,
                PocName = x.Name
            }).ToList();
        }
    }
}
