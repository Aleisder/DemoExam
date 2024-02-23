using DemoExam.Model;
using DemoExam.Repository;
using System.Collections.ObjectModel;
using System.Linq;

namespace DemoExam.Services
{
    public class UserService
    {
        public static readonly ObservableCollection<User> Users = new();

        static UserService()
        {
            UserRepository.GetAll().ForEach(x => Users.Add(x));
        }

        public static void AddUser(User user)
        {
            UserRepository.AddUser(user);
            Users.Add(UserRepository.GetLast());
        }

        public static void UpdateUser(int index, User user)
        {
            Users.RemoveAt(index);
            Users.Insert(index, user);
            UserRepository.UpdateUser(user);
        }

        public static void DeleteUser(User user)
        {
            Users.Remove(user);
            UserRepository.DeleteUser(user);
        }

    }
}
