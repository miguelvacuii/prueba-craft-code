namespace ExcelImport.Repository
{
    public class Repository<T> : IRepository<T>
    {

        private readonly Test2Entities persistenceService = new Test2Entities();

        public Repository() {
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
