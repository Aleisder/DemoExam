using DemoExam.Model;
using System.Collections.Generic;
using System.Linq;
using DemoExam.Configuration;
using System;

namespace DemoExam.Repository
{
    internal class UserRepository
    {
        private SqlSeverContext SqlServerContext = new();
        public UserRepository() { }

        private readonly List<User> users = new() {
            new User(0, "client", "Даниил", "Царенко", "client", Role.Client),
            new User(1, "admin", "Райан", "Гослинг", "admin", Role.Manager),
            new User(2, "executor", "executor", "фваы", "фва", Role.Executor)
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
            using(var context = SqlServerContext)
            {
                return users.Any(it => it.Login == login && it.Password == password);
            }

            //return users.Any(it => it.Login == login && it.Password == password);

        }


    }
}
