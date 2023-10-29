namespace ExcelImport.Repository.Exception
{
    public class DbEntityValidationException : System.Exception
    {
        public DbEntityValidationException(string message) : base(message) { }
    }
}
