using DemoExam.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoExam.Configuration
{
    public class SqlDatabase : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\AleisderDB; Initial Catalog=Department");
        }
    }
}