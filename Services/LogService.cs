using DemoExam.Model;
using DemoExam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Services
{
    public class LogService
    {
        public static void DeleteUserLog(User user)
        {
            string message = string.Format("User with ID={0} was deleted", user.Id);
            LogRepository.AddLog("UserRepository", message);
        }
    }
}
