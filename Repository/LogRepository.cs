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
        private static readonly SqlDatabase Context = new();

        public static void AddLog(string module, string description)
        {
            string query = "INSERT INTO Log (type_id, module, description, logged_at) VALUES (1, {0}, {1}, {2})";
            Context.Database.ExecuteSqlRaw(query, module, description, DateTime.Now);
            Context.SaveChanges();
        }

        public static List<Log> GetAll() => Context.Logs.ToList();
    }
}
