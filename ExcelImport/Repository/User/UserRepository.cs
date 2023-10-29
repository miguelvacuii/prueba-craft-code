using ExcelImport.Repository.Service;
using Entity = ExcelImport.Models.User;

namespace ExcelImport.Repository.User
{
    public class UserRepository : Repository<Entity.User> {
        private UserRepository(IPersistenceService persistenceService) : base (persistenceService) {}
    }
}
