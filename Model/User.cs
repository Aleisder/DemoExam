namespace DemoExam.Model
{
    internal class User
    {
        public int Id { get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public Role Role { set; get; }
        public User(int id, string login, string password, Role role)
        { 
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
