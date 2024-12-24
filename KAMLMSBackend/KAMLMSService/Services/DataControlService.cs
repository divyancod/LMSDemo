
using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class DataControlService : IDataControlService
    {
        private IContanctRepository contactsRepository;
        public DataControlService(IContanctRepository repo)
        {
            contactsRepository = repo;
        }
        public IList<RolesEntity> getAllRoles()
        {
            return contactsRepository.getAllRoles();
        }
    }
}
