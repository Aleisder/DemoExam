using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam.Model.Archive
{
    [Table("Case")]
    public class Case : ArchiveListItem
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("act_id")]
        public int ActId { get; set; }

        [Required]
        [Column("name")]
        public string? Name { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set;}

        [Column("closed_at")]
        public DateTime ClosedAt { get; set; }

        [Column("intruder")]
        public string? Intruder { get; set; }

        [Column("investigator_id")]
        //[ForeignKey("Id")]
        public int InvestigatorId { get; set; }

        [Column("section_id")]
        public int SectionId { get; set; }

        [Column("evidence")]
        public string? Evidence { get; set; }

        [Required]
        [Column("is_closed")]
        public bool IsClosed { get; set; }

        public override string GetCommand() => "None";

        public override int GetId() => Id;

        public override string GetName() => Name;

        public Case(int actId, string name, string intruder, int investigatorId, int sectionId, string evidence)
        {
            ActId = actId;
            Name = name;
            Intruder = intruder;
            InvestigatorId = investigatorId;
            SectionId = sectionId;
            Evidence = evidence;
        }
    }
}
