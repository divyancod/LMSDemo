
using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;

namespace KAMLMSRepository.Repositories
{
    public class DataControlRepository : BaseRepository, IDataControlRepository
    {
        public DataControlRepository(DatabaseContext context) : base(context)
        {
        }

        public IList<CountryEntity> GetAllCountryList()
        {
            return this.databaseContext.CountryEntity.ToList();
        }
    }
}
