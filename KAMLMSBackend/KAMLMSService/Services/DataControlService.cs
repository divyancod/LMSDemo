
using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class DataControlService : IDataControlService
    {
        private IContanctRepository contactsRepository;
        private IDataControlRepository datacontrol;
        public DataControlService(IContanctRepository repo,IDataControlRepository dataRepo)
        {
            contactsRepository = repo;
            datacontrol = dataRepo;
        }

        public IList<CountryEntity> getAllCountries()
        {
            return datacontrol.GetAllCountryList();
        }

        public IList<RolesEntity> getAllRoles()
        {
            return contactsRepository.getAllRoles();
        }

    }
}
