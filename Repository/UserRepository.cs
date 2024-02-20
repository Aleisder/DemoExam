using DemoExam.Configuration;
using DemoExam.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoExam.Repository
{
    public class UserRepository
    {
        private static readonly SqlDatabase Context = new();

        public static void AddUser(User user)
        {
            string query = "INSERT INTO [User] (first_name, last_name, login, password, position, role_id, created_at, updated_at) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})";
            Context.Database.ExecuteSqlRaw(query, user.Name, user.Surname, user.Login, user.Password, user.Position, 2, DateTime.Now, DateTime.Now);
            Context.SaveChanges();
        }

        public static List<User> GetAll() => Context.Users.ToList();

        public static User GetByLogin(string login) => Context
            .Users
            .Where(it => it.Login == login)
            .First();

        public static void UpdateUser(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
        }

        public static bool ValidateUser(string login, string password) => Context
            .Users
            .Any(it => it.Login == login && it.Password == password);

        public static void DeleteUser(User user)
        {
            Context.Users.Remove(user);
            Context.SaveChanges();
        }


    }
}
