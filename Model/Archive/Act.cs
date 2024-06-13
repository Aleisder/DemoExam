using System.Collections.Generic;
using System.Linq;

namespace DemoExam.Model.Archive
{
    public class Act
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Case> Cases { get; set; }

        public Act(int id, string name, List<Case> cases)
        {
            Id = id;
            Name = name;
            Cases = cases;
        }

        public int ClosedActs() => Cases.Where(x => x.IsClosed).Count();
        public int OpenedActs() => Cases.Where(x => !x.IsClosed).Count();
    }
}
