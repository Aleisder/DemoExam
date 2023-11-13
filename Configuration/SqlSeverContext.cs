using DemoExam.Entity;
using DemoExam.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Configuration
{
    class SqlSeverContext : System.Data.Entity.DbContext
    {
        public virtual System.Data.Entity.DbSet<Entity.User> Users { get; set; }
        public virtual System.Data.Entity.DbSet<Entity.Role> Roles { get; set; }

       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TecnhoService;");
        //}
    }
}
