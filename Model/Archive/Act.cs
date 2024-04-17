using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Model.Archive
{
    [Table("Act")]
    public class Act : ArchiveListItem
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column ("name")]
        public string Name { get; set; }

        [Required]
        [Column("volume_id")]
        public int VolumeId { get; set; }

        public Act(string name)
        {
            Name = name;
        }

        public override int GetId() => Id;

        public override string GetName() => Name;

        public override string GetCommand() => $"/act {Id}";

        public override string ToString() => Name;
    }
}
