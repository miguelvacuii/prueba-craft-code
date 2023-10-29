using System;
using ExcelImport.Shared.ValueObject;
using ExcelImport.Shared.ValueObject.Exception;

namespace ExcelImport.Models.User
{
    public class UserContactNumber : StringValueObject
    {

        public UserContactNumber(string value) : base(value)
        {

            if (String.IsNullOrEmpty(value))
            {
                InvalidAttributeException.FromEmpty("UserContactNumber");
            }

            if (value.GetType() != typeof(string))
            {
                InvalidAttributeException.FromValue("UserContactNumber", value);
            }

        }
    }
}
