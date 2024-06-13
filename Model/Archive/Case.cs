using System;
using DemoExam.Model.UserPool;

namespace DemoExam.Model.Archive
{
    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public DateTime ClosedAt { get; set; }
        public string Intruder { get; set; }
        public User Investigator { get; set; }
        public Section Section { get; set; }
        public string Evidence { get; set; }
        public bool IsClosed { get; set; }

        public Case(int id, string name, string intruder, User investigator, Section section, string evidence)
        {
            Id = id;
            Name = name;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Intruder = intruder;
            Investigator = investigator;
            Section = section;
            Evidence = evidence;
            IsClosed = false;
        }
    }
}
