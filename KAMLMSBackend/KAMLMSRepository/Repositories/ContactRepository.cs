using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;

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
    }
}
