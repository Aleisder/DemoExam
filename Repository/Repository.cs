using System;

namespace DemoExam.Repository
{
    public abstract class Repository
    {
        protected readonly string connectionString = $"Data Source={Environment.GetEnvironmentVariable("Server")}; Initial Catalog={Environment.GetEnvironmentVariable("Database")}";
    }
}
