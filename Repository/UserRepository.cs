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
        public static void AddUser(User user)
        {
            using(var database = new SqlDatabase())
            {
                string query = "INSERT INTO [User] (first_name, last_name, login, password, position, role_id, created_at, updated_at) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})";
                database.Database.ExecuteSqlRaw(query, user.Name, user.Surname, user.Login, user.Password, user.Position, 2, DateTime.Now, DateTime.Now);
                //database.Users.Add(user);
                database.SaveChanges();
            }
        }

        public static List<User> GetAll()
        {
            using(var context = new SqlDatabase())
            {
                return context.Users.ToList();
            }
        }

        public static void UpdateUser(User user)
        {
            using(var context = new SqlDatabase())
            {
                context.Users.Update(user);
            }
        }

        public static bool ValidateUser(string login, string password)
        {
            using(var context = new SqlDatabase())
            {
                return context.Users.Any(it => it.Login == login && it.Password == password);
            }
        }

        public static void DeleteUser(User user)
        {
            using(var context = new SqlDatabase())
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }


    }
}
