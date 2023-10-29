namespace ExcelImport.Repository.Service
{
    public interface IPersistenceService
    {
        void Add<T>(T entity);
        void SaveChanges();
    }
}
