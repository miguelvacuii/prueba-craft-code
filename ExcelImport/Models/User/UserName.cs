using System;
using ExcelImport.Shared.ValueObject;
using ExcelImport.Shared.ValueObject.Exception;

namespace ExcelImport.Models.User
{
    public class UserName : StringValueObject
    {

        public UserName(string value) : base(value)
        {

            if (String.IsNullOrEmpty(value))
            {
                InvalidAttributeException.FromEmpty("UserName");
            }

            if (value.GetType() != typeof(string))
            {
                InvalidAttributeException.FromValue("UserName", value);
            }

        }
    }
}
