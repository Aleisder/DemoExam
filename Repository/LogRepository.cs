using DemoExam.Model.Log;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DemoExam.Repository
{
    public class LogRepository : Repository
    {
        public List<Log> GetAll()
        {
            string query = "SELECT * FROM [Log]";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            var logs = new List<Log>();
            while (reader.Read())
            {
                var log = reader.MapToLog();
                logs.Add(log);
            }
            reader.Close();
            connection.Close();
            return logs;
        }

        public int Add(string module, string description)
        {
            string query = "INSERT INTO [Log] (type_id, module, description, logged_at) VALUES (1, @module, @description, GETDATE()); SELECT CAST(SCOPE_IDENTITY() AS int);";
            var moduleParam = new SqlParameter("module", module);
            var descriptionParam = new SqlParameter("description", description);
            SqlParameter[] parameters = { moduleParam, descriptionParam };
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);
            using var reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            reader.Close();
            connection.Close();
            return id;
        }

        public Log GetById(int id) =>
            GetAll()
            .Where(log => log.Id == id)
            .First();
    }
}
