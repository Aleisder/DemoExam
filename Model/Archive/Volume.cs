using System.Collections.Generic;

namespace DemoExam.Model.Archive
{
    public class Volume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Act> Acts { get; set; }

        public Volume(int id, string name, List<Act> acts)
        {
            Id = id;
            Name = name;
            Acts = acts;
        }

        // сколько дел внутри тома
        public int GetCaseCount()
        {
            int counter = 0;
            foreach (Act act in Acts)
                counter += act.Cases.Count;
            return counter;
        }
    }
}
