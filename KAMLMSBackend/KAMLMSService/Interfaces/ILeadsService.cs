﻿using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Constants;

namespace KAMLMSService.Interfaces
{
    public interface ILeadsService
    {
        Guid AddLeads(LeadsRequest leadsRequest, Guid UserId);
        LeadsEntity GetLead(Guid id);
        IList<LeadStatusEntity> GetLeadTypes();
        IList<LeadInfoResponse> GetLeads(int type,int skip, int take);
        DashboardResponseWithType GetLeadDashboard();
        LeadsEntity UpdateLead(LeadsEntity leadsId);
        void UpdateLeadStatus(UpdateLead request);
        void SyncLeadsToPlace();
    }
}
