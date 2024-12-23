using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;

namespace KAMLMSService.Interfaces
{
    public interface ILeadsService
    {
        Guid AddLeads(LeadsRequest leadsRequest);
        LeadsEntity GetLead(Guid id);
    }
}
