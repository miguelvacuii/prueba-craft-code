using ExcelImport.Repository.Exception;
using ExcelImport.Repository.Service;

namespace ExcelImport.Repository
{
    public class Repository<T> : IRepository<T>
    {

        private readonly IPersistenceService persistenceService;

        public Repository(IPersistenceService persistenceService) {
            this.persistenceService = persistenceService;
        }

        public void Add(T entity)
        {
            try {
                persistenceService.Add<T>(entity);
                persistenceService.SaveChanges();
            } catch (DbEntityValidationException ex) {
                throw RepositoryException.FromEntity(entity.ToString(), ex);
            }
        }
    }
}
