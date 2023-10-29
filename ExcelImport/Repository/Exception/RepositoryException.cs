using System.Collections.Generic;

namespace ExcelImport.Repository.Exception
{
    public class RepositoryException : System.Exception
    {
        public RepositoryException(string message) : base (message) { }

        public static RepositoryException FromEntity(string entity, dynamic values) {
            List<string> message = new List<string>();
            message.Add(string.Format("Persistence error in entity {0}", entity));
            foreach (var entityValidationErrors in values.EntityValidationErrors) {
                foreach (var validationError in entityValidationErrors.ValidationErrors) {
                    message.Add(
                        string.Format("Property: {0} Error: {0}",
                        validationError.PropertyName,
                        validationError.ErrorMessage)
                    );
                }
            }
            throw new RepositoryException(message.ToString());
        }
    }
}
