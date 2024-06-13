using DemoExam.Model.Log;
using System;
using System.Data.SqlClient;
using Type = DemoExam.Model.Log.Type;

namespace DemoExam.Repository
{
    public static class Mappers
    {
        public static Log MapToLog(this SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            var type = new Type(1, "INFO");
            string module = reader.GetString(2);
            string description = reader.GetString(3);
            DateTime loggedAt = reader.GetDateTime(4);

            var log = new Log(id, type, module, description, loggedAt);
            return log;
        }
    }
}
