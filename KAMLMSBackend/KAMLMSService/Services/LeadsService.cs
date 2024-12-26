using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Constants;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class LeadsService : ILeadsService
    {
        private ILeadsRepository repository;
        public LeadsService(ILeadsRepository leadsRepository)
        {
            repository = leadsRepository;
        }
        public Guid AddLeads(LeadsRequest leadsRequest, Guid UserId)
        {
            if (string.IsNullOrEmpty(leadsRequest.ParentEnterpriseName))
            {
                throw new CustomException("Parent Enterprise can not be empty");
            }
            if (string.IsNullOrEmpty(leadsRequest.CompanyName))
            {
                throw new CustomException("Company Name can not be empty");
            }
            if (string.IsNullOrEmpty(leadsRequest.CompanyEmail))
            {
                throw new CustomException("Company Email can not be empty");
            }
            if (string.IsNullOrEmpty(leadsRequest.CompanyAddress))
            {
                throw new CustomException("Company Adderss can not be empty");
            }
            if (string.IsNullOrEmpty(leadsRequest.Country))
            {
                throw new CustomException("Country can not be empty");
            }
            if (string.IsNullOrEmpty(leadsRequest.TimeZone))
            {
                throw new CustomException("TimeZone can not be empty");
            }
            if (string.IsNullOrEmpty(leadsRequest.WorkingHourStart))
            {
                throw new CustomException("Working hours can not be empty");
            }
            if (string.IsNullOrEmpty(leadsRequest.WorkingHourEnd))
            {
                throw new CustomException("Working hours can not be empty");
            }
            LeadsEntity entity = new LeadsEntity
            {
                ParentEnterpriseName = leadsRequest.ParentEnterpriseName,
                CompanyName = leadsRequest.CompanyName,
                CompanyEmail = leadsRequest.CompanyEmail,
                CompanyAddress = leadsRequest.CompanyAddress,
                Country = leadsRequest.Country,
                TimeZone = leadsRequest.TimeZone,
                WorkingHourEnd = leadsRequest.WorkingHourEnd,
                WorkingHourStart = leadsRequest.WorkingHourStart,
                Comment = leadsRequest.Comment,
                AddedById = UserId,
                AssignedToId = UserId,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                StatusId = (int)LeadStatus.New
            };
            entity = repository.AddLead(entity);
            return entity.Id;
        }

        public LeadsEntity GetLead(Guid id)
        {
            return repository.GetLead(id);
        }

        public IList<LeadInfoResponse> GetLeads(int type, int page, int take)
        {
            IList<LeadsEntity> list = repository.GetLeads(take, page, type);
            IList<LeadInfoResponse> response = new List<LeadInfoResponse>();
            foreach (var item in list)
            {
                response.Add(new LeadInfoResponse { AssignedTo = item.AssignedTo.FullName, CompanyName = item.CompanyName, EnterpriseName = item.ParentEnterpriseName, Id = item.Id, Status = item.StatusId.ToString() });
            }
            return response;
        }

        public IList<LeadStatusEntity> GetLeadTypes()
        {
            return repository.GetLeadTypes();
        }

        public DashboardResponseWithType GetLeadDashboard()
        {

            var list = repository.GetDataForDashboard();
            Dictionary<string, IList<LeadInfoResponse>> dictionary = new Dictionary<string, IList<LeadInfoResponse>>();
            var leadTypes = repository.GetLeadTypes();

            foreach (var item in leadTypes)
            {
                dictionary.Add(item.Status, new List<LeadInfoResponse>());
            }

            foreach (var item in list)
            {
                if (dictionary.ContainsKey(item.Status))
                {
                    dictionary[item.Status].Add(new LeadInfoResponse { AssignedTo = item.FullName, CompanyName = item.CompanyName, EnterpriseName = item.ParentEnterpriseName, Id = item.Id, Status = item.Status, StatusId = item.StatusId });
                }
            }
            DashboardResponseWithType response = new DashboardResponseWithType();
            foreach (var item in leadTypes)
            {
                response.data.Add(new DashboardResponseWithLeads { id = item.id, Status = item.Status, leads = dictionary[item.Status] });
            }
            return response;
        }

        public LeadsEntity UpdateLead(LeadsEntity leadsId)
        {
            return repository.UpdateLead(leadsId);
        }
    }
}
