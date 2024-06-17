namespace DemoExam.Model.Log
{
    public class Type
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public Type(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public override string ToString() => Value;
    }
}
