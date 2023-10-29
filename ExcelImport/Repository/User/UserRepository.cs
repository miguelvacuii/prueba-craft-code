using Entity = ExcelImport.Models.User;

namespace ExcelImport.Repository.User
{
    public class UserRepository : Repository<Entity.User>
    {
        public UserRepository()
        {
        }
    }
}
