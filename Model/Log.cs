using System;

namespace DemoExam.Model
{
    class Log
    {
        public int Id { get; set; }
        public LogType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Log(int id, LogType type, string description, DateTime loggedAt)
        {
            Id = id;
            Type = type;
            Description = description;
            CreatedAt = loggedAt;
        }
    }
}
