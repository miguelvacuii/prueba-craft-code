using System;
using ExcelImport.Shared.ValueObject;
using ExcelImport.Shared.ValueObject.Exception;

namespace ExcelImport.Models.User
{
    public class UserAddress : StringValueObject
    {

        public UserAddress(string value) : base(value)
        {

            if (String.IsNullOrEmpty(value))
            {
                InvalidAttributeException.FromEmpty("UserAddress");
            }

            if (value.GetType() != typeof(string))
            {
                InvalidAttributeException.FromValue("UserAddress", value);
            }

        }
    }
}