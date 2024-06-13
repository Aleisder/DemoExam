using System;

namespace DemoExam.Model.UserPool
{
    public class User
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public Role Role { set; get; }
        public DateTime? CreatedAt { set; get; }
        public DateTime? UpdatedAt { set; get; }

        public User(string name, string surname, string login, string password, Role role)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Role = role;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public User(int id, string name, string surname, string login, string password, Role role, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Role = role;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public override string ToString() => $"{Name} {Surname}";
    }
}
