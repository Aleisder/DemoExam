using DemoExam.Model;
using DemoExam.Model.Archive;
using Microsoft.EntityFrameworkCore;
using System;
using Type = DemoExam.Model.Type;

namespace DemoExam.Configuration
{
    public class SqlDatabase : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Section> Sections { get; set; }

        private readonly string? Server = Environment.GetEnvironmentVariable("Server");
        private readonly string? DatabaseName = Environment.GetEnvironmentVariable("Database");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source={Server}; Initial Catalog={DatabaseName}");
        }
    }
}