using KAMLMSContracts.Entities;
using KAMLMSContracts.ResponseModels;

namespace KAMLMSRepository.Interfaces
{
    public interface ILeadsRepository
    {
        LeadsEntity AddLead(LeadsEntity leads);
        LeadsEntity GetLead(Guid id);
        IList<LeadStatusEntity> GetLeadTypes();
        IList<LeadsEntity> GetLeads(int take, int page, int type);
        IList<DashboardResponse> GetDataForDashboard();
        LeadsEntity UpdateLead(LeadsEntity leadsId);
        void SyncLead();
    }
}
