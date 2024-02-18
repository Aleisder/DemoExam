using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Model
{
    public class Role
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column("role")]
        public string? Value { get; set; } = null!;
    }
}
