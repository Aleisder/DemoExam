using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Model
{
    [Table("Log")]
    public class Log
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("type_id")]
        [ForeignKey("Id")]
        public Type? Type { get; set; }

        [Column("module")]
        public string? Module { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("logged_at")]
        public DateTime LoggedAt { get; set; }

        public Log() { }

        public Log(string module, string description)
        {
            Module = module;
            Description = description;
            LoggedAt = DateTime.Now;
        }
    }
}
