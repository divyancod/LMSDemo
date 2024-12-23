using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;

namespace KAMLMSRepository.Repositories
{
    public class LeadsRepository : BaseRepository, ILeadsRepository
    {
        public LeadsRepository(DatabaseContext context) : base(context)
        {
        }

        public LeadsEntity AddLead(LeadsEntity leads)
        {
            databaseContext.LeadsEntity.Add(leads);
            databaseContext.SaveChanges();
            return leads;
        }

        public LeadsEntity GetLead(Guid id)
        {
            return databaseContext.LeadsEntity.FirstOrDefault(e => e.ResturantId == id);
        }
    }
}
