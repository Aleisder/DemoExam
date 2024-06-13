using DemoExam.Enums;
using DemoExam.Model.Log;
using DemoExam.Model.UserPool;
using DemoExam.Repository;
using System.Collections.ObjectModel;

namespace DemoExam.Services
{
    public class LogService
    {
        public readonly ObservableCollection<Log> logs = new();
        private readonly LogRepository logRepository = new();

        public LogService()
        {
            logRepository.GetAll().ForEach(log => logs.Add(log));
        }

        public void Add(User user, LogEvent logEvent)
        {
            string message = logEvent switch
            {
                LogEvent.CREATE => $"Создан новый пользователь [Логин: {user.Login}, Фамилия: {user.Surname}, Имя: {user.Name}]",
                LogEvent.UPDATE => $"Обновлены данные о пользователе с ID - {user.Id}",
                LogEvent.DELETE => $"Удалён аккаунт с ID - {user.Id}",
                LogEvent.LOG_IN => $"Вход в аккаунт [ID: {user.Id}, Логин: {user.Login}]",
                LogEvent.LOG_OUT => $"Выход из аккаунта [ID: {user.Id}, Логин: {user.Login}]",
                _ => "ОШИБКА. Неожидаемый лог"
            };
            int id = logRepository.Add("UserRepository", message);
            logs.Add(logRepository.GetById(id));
        }

    }
}
