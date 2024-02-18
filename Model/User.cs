using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Model
{
    [Table("User")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string? Name { set; get; }
        [Column("last_name")]
        public string? Surname { set; get; }
        [Column("login")]
        public string? Login { set; get; }
        [Column("password")]
        public string? Password { set; get; }
        [Column("position")]
        public string? Position { set; get; }
        [Column("role_id")]
        [ForeignKey("Id")]
        public Role? Role { set; get; }
        [Column("created_at")]
        public DateTime? CreatedAt { set; get; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { set; get; }
    }
}
