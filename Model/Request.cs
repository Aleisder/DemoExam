using System;

namespace DemoExam.Model
{
    internal class Request
    {
        public long Id { get; set; }
        public DateOnly Date { get; }
        public string Device { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }
        public User Client { get; set; }

        public Request(string device, Type type, string description, User client)
        { 
            Id = new Random().Next(0, int.MaxValue);
            Date = new DateOnly(DateTime.Today.Year, DateTime.Now.Month, DateTime.Now.Day);
            Device = device;
            Type = type;
            Description = description;
            Client = client;
        }

    }
}
