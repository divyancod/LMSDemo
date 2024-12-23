using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
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
        public Guid AddLeads(LeadsRequest leadsRequest)
        {
            if(string.IsNullOrEmpty(leadsRequest.ResturantName))
            {
                throw new CustomException("Resturant Name can not be empty");
            }
            if (string.IsNullOrEmpty(leadsRequest.ResturantAddress))
            {
                throw new CustomException("Resturant Address can not be empty");
            }
            LeadsEntity entity= new LeadsEntity
            {
                ResturantName = leadsRequest.ResturantName,
                ResturantAddress = leadsRequest.ResturantAddress,
                Comment = leadsRequest.Comment,
                CreatedAt = DateTime.Now           
            };
            entity = repository.AddLead(entity);
            return entity.ResturantId;
        }

        public LeadsEntity GetLead(Guid id)
        {
            return repository.GetLead(id);
        }
    }
}
