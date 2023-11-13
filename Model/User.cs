namespace DemoExam.Model
{
    internal class User
    {
        public int Id { get; }
        public string Login { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Password { set; get; }
        public Role Role { set; get; }
        public User(int id, string login, string name, string surname, string password, Role role)
        { 
            Id = id;
            Login = login;
            Name = name;
            Surname = surname;
            Password = password;
            Role = role;
        }
    }
}
