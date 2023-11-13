using DemoExam.Entity;
using DemoExam.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Configuration
{
    class SqlSeverContext : DbContext
    {
        public virtual DbSet<Entity.User> Users { get; set; }
        public virtual DbSet<Entity.Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TecnhoService;");
        }
    }
}
