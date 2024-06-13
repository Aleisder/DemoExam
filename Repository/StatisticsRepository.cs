using System.Data.SqlClient;

namespace DemoExam.Repository
{
    public class StatisticsRepository : Repository
    {

        public int AllCount()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT COUNT(*) AS 'all' FROM [Case]";
            var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            connection.Close();
            return count;
        }

        public int ClosedCount()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT COUNT(*) AS 'closed' FROM [Case] WHERE is_closed = 1";
            var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            connection.Close();
            return count;
        }

    }
}
