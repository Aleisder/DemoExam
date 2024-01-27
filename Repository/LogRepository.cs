using DemoExam.Model;
using System.Collections.Generic;

namespace DemoExam.Repository
{
    class LogRepository
    {
        private readonly List<Log> logs = new()
        {
            new Log(0, LogType.INFO, "Создан новый пользователь"),
            new Log(0, LogType.INFO, "Выполнен вход в учётную запись"),
            new Log(0, LogType.INFO, "Выполнен выход из учётной записи"),
            new Log(0, LogType.INFO, "Создан новый пользователь"),
            new Log(0, LogType.INFO, "Выполнен вход в учётную запись"),
            new Log(0, LogType.INFO, "Выполнен выход из учётной записи"),
            new Log(0, LogType.INFO, "Создан новый пользователь"),
            new Log(0, LogType.INFO, "Выполнен вход в учётную запись"),
            new Log(0, LogType.INFO, "Выполнен выход из учётной записи"),
            new Log(0, LogType.INFO, "Создан новый пользователь"),
            new Log(0, LogType.INFO, "Выполнен вход в учётную запись"),
            new Log(0, LogType.INFO, "Выполнен выход из учётной записи"),
            new Log(0, LogType.INFO, "Создан новый пользователь"),
            new Log(0, LogType.INFO, "Выполнен вход в учётную запись"),
            new Log(0, LogType.INFO, "Выполнен выход из учётной записи"),
        };

        public void AddLog(Log log) => logs.Add(log);

        public List<Log> GetAll() => logs;
    }
}
