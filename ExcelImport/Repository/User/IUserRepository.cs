using Entity = ExcelImport.Models.User;

namespace ExcelImport.Repository.User
{
    public interface IUserRepository : IRepository<Entity.User> {}
}
