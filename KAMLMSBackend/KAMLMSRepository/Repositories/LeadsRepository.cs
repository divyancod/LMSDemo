using KAMLMSContracts.Entities;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public IList<DashboardResponse> GetDataForDashboard()
        {
            return databaseContext.DashboardResponse.FromSqlRaw("exec GetDashboardProducts").ToList();
        }

        public LeadsEntity GetLead(Guid id)
        {
            return databaseContext.LeadsEntity.FirstOrDefault(e => e.Id == id);
        }

        public IList<LeadsEntity> GetLeads(int take, int page, int type)
        {
            return databaseContext.LeadsEntity.Include(x => x.AssignedTo).Include(x => x.status).Where(x => x.StatusId == type).Skip(page * take).Take(take).ToList();
        }

        public IList<LeadStatusEntity> GetLeadTypes()
        {
            return databaseContext.LeadStatusEntity.ToList();
        }
    }
}
