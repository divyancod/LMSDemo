namespace KAMLMSRepository.Repositories
{
    abstract public class BaseRepository
    {
        protected DatabaseContext databaseContext;

        public BaseRepository(DatabaseContext context)
        {
            databaseContext = context;
        }
    }
}
