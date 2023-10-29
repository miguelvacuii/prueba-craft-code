using ExcelImport.Repository.Service;

namespace ExcelImport.Repository
{
    public class Repository<T> : IRepository<T>
    {

        private readonly IPersistenceService persistenceService;

        private Repository(IPersistenceService persistenceService) {
            this.persistenceService = persistenceService;
        }

        public void Add(T entity)
        {
            // TO-DO
        }

        public void SaveChanges()
        {
            // TO-DO
        }
    }
}
