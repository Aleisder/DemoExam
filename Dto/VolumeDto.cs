namespace DemoExam.Dto
{
    public class VolumeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActCount { get; set; }
        public int CaseCount { get; set; }

        public VolumeDto(int id, string name, int actAmount, int caseCount)
        {
            Id = id;
            Name = name;
            ActCount = actAmount;
            CaseCount = caseCount;
        }
    }
}
