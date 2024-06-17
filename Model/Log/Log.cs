using System;

namespace DemoExam.Model.Log
{
    public class Log
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public DateTime LoggedAt { get; set; }

        public Log(int id, Type type, string module, string description, DateTime loggedAt)
        {
            Id = id;
            Type = type;
            Module = module;
            Description = description;
            LoggedAt = loggedAt;
        }
    }
}
