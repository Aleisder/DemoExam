using DemoExam.Model.UserPool;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DemoExam.Repository
{
    public class UserRepository : Repository
    {
        public int Add(User user)
        {
            string query = "INSERT INTO [User] (first_name, last_name, login, password, role_id, created_at, updated_at) VALUES (@first_name, @last_name, @login, @password, @role_id, @created_at, @updated_at); SELECT CAST(SCOPE_IDENTITY() AS int)";
            connection.Open();
            var command = new SqlCommand(query, connection);
            var name = new SqlParameter("first_name", user.Name);
            var lastName = new SqlParameter("last_name", user.Name);
            var login = new SqlParameter("login", user.Login);
            var password = new SqlParameter("password", user.Password);
            var roleId = new SqlParameter("role_id", user.Role.Id);
            var createdAt = new SqlParameter("created_at", user.CreatedAt);
            var updatedAt = new SqlParameter("updated_at", user.UpdatedAt);

            SqlParameter[] parameters = { name, lastName, login, password, roleId, createdAt, updatedAt };
            command.Parameters.AddRange(parameters);

            using var reader = command.ExecuteReader();

            reader.Read();
            int userId = reader.GetInt32(0);

            reader.Close();
            connection.Close();

            return userId;
        }

        public List<User> GetAll()
        {
            connection.Open();
            string query = "SELECT [User].[id], first_name, last_name, login, password, role_id, [Role].[name], created_at, updated_at FROM [User] JOIN [Role] ON [Role].id = [User].[role_id];";
            var users = new List<User>();
            var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string firstName = reader.GetString(1);
                string lastName = reader.GetString(2);
                string login = reader.GetString(3);
                string password = reader.GetString(4);
                int roleId = reader.GetInt32(5);
                string roleName = reader.GetString(6);
                DateTime createdAt = reader.GetDateTime(7);
                DateTime updatedAt = reader.GetDateTime(8);

                var user = new User(id, firstName, lastName, login, password, new Role(roleId, roleName), createdAt, updatedAt);
                users.Add(user);
            }
            reader.Close();
            connection.Close();
            return users;
        }

        public List<Role> GetRoles()
        {
            connection.Open();
            string query = "SELECT * FROM [Role]";
            SqlCommand command = new(query, connection);
            var roles = new List<Role>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    var role = new Role(id, name);
                    roles.Add(role);
                }
                reader.Close();
            }
            connection.Close();
            return roles;
        }

        private Role GetRoleById(int id) => GetRoles().Where(role => role.Id == id).First();

        public User GetById(int id) =>
            GetAll()
            .Where(user => user.Id == id)
            .First();

        public void Update(User user)
        {
            string query = "UPDATE [User] SET first_name = @first_name, last_name = @last_name, login = @login, password = @password, role_id = @role_id, updated_at = @updated_at WHERE id = @id";
            connection.Open();
            var command = new SqlCommand(query, connection);

            var firstName = new SqlParameter("first_name", user.Name);
            var lastName = new SqlParameter("last_name", user.Name);
            var login = new SqlParameter("login", user.Login);
            var password = new SqlParameter("password", user.Password);
            var roleId = new SqlParameter("role_id", user.Role.Id);
            var updatedAt = new SqlParameter("updated_at", user.UpdatedAt);
            var id = new SqlParameter("id", user.Id);

            SqlParameter[] parameters = { firstName, lastName, login, password, roleId, updatedAt, id };
            command.Parameters.AddRange(parameters);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(User user)
        {
            string query = "DELETE FROM [User] WHERE id = @id";
            var id = new SqlParameter("id", user.Id);
            var command = new SqlCommand(query, connection);
            connection.Open();
            command.Parameters.Add(id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool Validate(string login, string password) =>
            GetAll()
            .Any(user => user.Login == login && user.Password == password);

        public User GetByLogin(string login) => GetAll().Where(user => user.Login == login).First();

        public List<User> GetInvestigators() =>
            GetAll()
            .Where(user => user.Role.Name == "Следователь")
            .ToList();
    }
}
