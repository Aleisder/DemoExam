﻿using DemoExam.Enums;
using DemoExam.Model;
using DemoExam.Repository;
using System.Collections.ObjectModel;

namespace DemoExam.Services
{
    public class LogService
    {
        public static readonly ObservableCollection<Log> Logs = new();

        static LogService()
        {
            LogRepository.GetAll().ForEach(log => Logs.Add(log));
        }

        public static void AddLog(User user, LogEvent logEvent)
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
            LogRepository.AddLog("UserRepository", message);
            Logs.Add(LogRepository.GetLast());
        }

    }
}
