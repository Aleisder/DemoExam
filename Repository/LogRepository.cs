using DemoExam.Configuration;
using DemoExam.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoExam.Repository
{
    public class LogRepository
    {

        public static void AddLog(string module, string description)
        {
            var log = new Log()
            {
                Module = module,
                Description = description,
                LoggedAt = DateTime.Now
            };

            string query = "INSERT INTO Log (type_id, module, description, logged_at) VALUES (1, {0}, {1}, {2})";

            using (var context = new SqlDatabase())
            {
                context.Database.ExecuteSqlRaw(query, module, description, DateTime.Now);
                context.SaveChanges();
            }
        }

        public static List<Log> GetAll()
        {
            using(var context = new SqlDatabase())
            {
                return context.Logs.ToList();
            }
        }
    }
}
