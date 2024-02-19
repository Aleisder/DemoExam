using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Model
{
    [Table("Type")]
    public class Type
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("type")]
        public string? Value { get; set; }

        public Type(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public override string ToString() => Value;
    }
}
