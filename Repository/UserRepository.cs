using DemoExam.Model;
using System.Collections.Generic;
using System.Linq;

namespace DemoExam.Repository
{
    internal class UserRepository
    {
        public UserRepository() { }

        private readonly List<User> users = new() { 
            new User(0, "client", "client", Role.Client),
            new User(1, "admin", "admin", Role.Manager),
            new User(2, "executor", "executor", Role.Executor)
        };

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUserByLogin(string login)
        {
            return users.Find(user => user.Login == login);
        }

        public bool ValidateUser(string login, string password)
        {
            return users.Any(it => it.Login == login && it.Password == password);
        }

        
    }
}
