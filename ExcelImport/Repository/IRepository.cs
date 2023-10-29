namespace ExcelImport.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void SaveChanges();
    }
}
