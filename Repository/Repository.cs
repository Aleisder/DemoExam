using System;
using System.Data.SqlClient;

namespace DemoExam.Repository
{
    public abstract class Repository
    {
        private readonly string connectionString;
        protected readonly SqlConnection connection;

        protected Repository()
        {
            connectionString = $"Data Source={Environment.GetEnvironmentVariable("Server")}; Initial Catalog={Environment.GetEnvironmentVariable("Database")}";
            connection  = new SqlConnection(connectionString) ;
        }
    }
}
