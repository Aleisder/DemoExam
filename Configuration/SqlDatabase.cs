using DemoExam.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DemoExam.Configuration
{
    public class SqlDatabase : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Model.Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        private readonly string? Server = Environment.GetEnvironmentVariable("Server");
        private readonly string? DatabaseName = Environment.GetEnvironmentVariable("Database");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source={Server}; Initial Catalog={DatabaseName}");
        }
    }
}