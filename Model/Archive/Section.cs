namespace DemoExam.Model.Archive
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Punishment { get; set; }

        public Section(int id, string name, string punishment)
        {
            Id = id;
            Name = name;
            Punishment = punishment;
        }
    }
}
