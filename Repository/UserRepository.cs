using DemoExam.Model;
using System.Collections.Generic;

namespace DemoExam.Repository
{
    class UserRepository
    {
        private static List<User> Users = new() {
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер"),
            new (1, "Иванов", "Иван", "ivanov@gmail.com", "asdfjkh20", "Старший инженер")
        };

        public void AddUser(User user) => Users.Add(user);

        public List<User> GetAll() => Users;

        public bool ValidateUser(string login, string password)
        {
            return true;

        }


    }
}
