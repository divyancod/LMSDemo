
using KAMLMSContracts.Entities;

namespace KAMLMSRepository.Interfaces
{
    public interface IDataControlRepository
    {
        IList<CountryEntity> GetAllCountryList();
    }
}
