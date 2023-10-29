namespace ExcelImport.Shared.ValueObject
{
    public abstract class StringValueObject : BaseValueObject<string>
    {
        public string Value { get; }

        public StringValueObject(string value) : base (value)
        {
            Value = value;
        }
    }
}
