namespace DemoExam.Dto
{
    public class ActDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AllCaseCount { get; set; }
        public int OpenCaseCount {  get; set; }
        public int CloseCaseCount { get; set; }

        public ActDto(int id, string name, int allCaseCount, int openCaseCount, int closeCaseCount)
        {
            Id = id;
            Name = name;
            AllCaseCount = allCaseCount;
            OpenCaseCount = openCaseCount;
            CloseCaseCount = CloseCaseCount;
        }
    }
}
