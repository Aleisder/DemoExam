using System;

namespace DemoExam.Dto
{
    class CaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Intruder { get; set; }
        public string Investigator { get; set; }
        public string SectionName { get; set; }
        public string Evidence { get; set; }

        public CaseDto(int id, string name, int actId, DateTime createdAt, string intruder, string investigator, string sectionName, string evidence)
        {
            Id = id;
            Name = name;
            ActId = actId;
            CreatedAt = createdAt;
            Intruder = intruder;
            Investigator = investigator;
            SectionName = sectionName;
            Evidence = evidence;
        }
    }
}
