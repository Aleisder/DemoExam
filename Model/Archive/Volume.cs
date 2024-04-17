using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;


namespace DemoExam.Model.Archive
{
    [Table("Volume")]
    public class Volume : ArchiveListItem
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column ("name")]
        public string Name { get; set; }

        public Volume(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override int GetId() => Id;

        public override string GetName() => Name;

        public override string GetCommand() => $"/volume {Id}";
    }
}
