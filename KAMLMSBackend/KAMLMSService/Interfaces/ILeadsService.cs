using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;

namespace KAMLMSService.Interfaces
{
    public interface ILeadsService
    {
        Guid AddLeads(LeadsRequest leadsRequest, Guid UserId);
        LeadsEntity GetLead(Guid id);
        IList<LeadStatusEntity> GetLeadTypes();
        IList<LeadInfoResponse> GetLeads(int type,int skip, int take);
        DashboardResponseWithType GetLeadDashboard();
    }
}
