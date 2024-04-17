using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Model
{
    [Table("Role")]
    public class Role
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column("role")]
        public string? Value { get; set; } = null!;

        public static Role CreateFromValue(string value)
        {
            return value switch
            {
                "Администратор" => new Role { Id = 1, Value = "Администратор" },
                "Начальник отдела" => new Role { Id = 2, Value = "Начальник отдела" },
                "Сотрудник отдела" => new Role { Id = 3, Value = "Сотрудник отдела" },
                _ => new Role { Id = 4, Value = "Error" },
            };
        }
    }
}
