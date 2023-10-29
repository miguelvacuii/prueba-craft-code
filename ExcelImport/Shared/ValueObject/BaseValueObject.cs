namespace ExcelImport.Shared.ValueObject
{
    public class BaseValueObject<T>
    {
        private T Value;

        public BaseValueObject(T value)
        {
            this.Value = value;
        }

        public T GetValue()
        {
            return Value;
        }

        public bool Equals(BaseValueObject<T> valueObject)
        {
            return GetValue().Equals(valueObject.GetValue()) ? true : false;
        }
    }
}
