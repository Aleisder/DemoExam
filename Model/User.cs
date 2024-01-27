using System;

namespace DemoExam.Model
{
    class User
    {
        public int Id { get; }
        public string Surname { set; get; }
        public string Name { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string Position { set; get; }
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }
        public User(int id, string surname, string name, string login, string password, string position)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Login = login;
            Password = password;
            Position = position;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
