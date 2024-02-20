﻿using DemoExam.Enums;
using DemoExam.Model;
using DemoExam.Repository;
using DemoExam.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoExam.View
{
    public partial class ManagerScreen : Window
    {
        private readonly List<TextBox> TextFields;
        private readonly User CurrentUser = new();
        private readonly ObservableCollectionListSource<User> Users = new();
        private readonly ObservableCollectionListSource<Log> Logs = new();

        public ManagerScreen(string login)
        {
            InitializeComponent();

            CurrentUser = UserRepository.GetByLogin(login);
            LogService.AddLog(CurrentUser, LogEvent.LOG_IN);

            UserRepository.GetAll().ForEach(user => { Users.Add(user); });
            LogRepository.GetAll().ForEach(log => { Logs.Add(log); });

            UserListView.ItemsSource = Users;
            LogListView.ItemsSource = Logs;

            TextFields = new()
            {
                SurnameTextxBox,
                NameTextBox,
                LoginTextBox,
                PasswordTextBox,
                PositionTextBox
            };
        }

        private void OpenAddUserWindowClick(object sender, RoutedEventArgs e) => OpenAddUserWindow();

        private void CloseAddUserWindowClick(object sender, RoutedEventArgs e) => CloseAddUserWindow();

        private void CloseAddUserWindow()
        {
            RequestGrid.Visibility = Visibility.Collapsed;
            ClearTextBoxes();
        }

        private void OpenAddUserWindow()
        {
            RequestGrid.Visibility = Visibility.Visible;
            RequestButton.Visibility = Visibility.Visible;
            UpdateButton.Visibility = Visibility.Collapsed;
        }

        private void ClearTextBoxes() => TextFields.ForEach(x => x.Clear());

        private void ConfirmUserClick(object sender, RoutedEventArgs e)
        {
            var user = new User()
            {
                Name = NameTextBox.Text.Trim(),
                Surname = SurnameTextxBox.Text.Trim(),
                Login = LoginTextBox.Text.Trim(),
                Password = PasswordTextBox.Text.Trim(),
                Position = PositionTextBox.Text.Trim(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            UserRepository.AddUser(user);
            Users.Add(UserRepository.GetLast());
            LogService.AddLog(user, LogEvent.CREATE);
            Logs.Add(LogRepository.GetAll().Last());
            CloseAddUserWindow();
            ClearTextBoxes();
        }

        private void ExitClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из учётной записи?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                LogService.AddLog(CurrentUser, LogEvent.LOG_OUT);
                var screen = new AuthorizationScreen();
                screen.Show();
                Close();
            }
        }

        private void DeleteUserClick(object sender, RoutedEventArgs e)
        {
            int index = UserListView.SelectedIndex;
            User user = Users.ElementAt(index);
            if (user != null)
            {
                UserRepository.DeleteUser(user);
                Users.Remove(user);
                LogService.AddLog(user, LogEvent.DELETE);
                Logs.Add(LogRepository.GetLast());
            }
        }

        private void UserListItemClick(object sender, SelectionChangedEventArgs e)
        {
            switch (UserListView.SelectedItems.Count)
            {
                case 0:
                    DisableEditAndDeleteButtons();
                    break;
                case 1:
                    EnableEditAndDeleteButtons();
                    break;
                default:
                    EditButton.IsEnabled = false;
                    DeleteButton.IsEnabled = true;
                    break;
            }
        }

        private void EnableEditAndDeleteButtons()
        {
            DeleteButton.IsEnabled = true;
            EditButton.IsEnabled = true;
        }

        private void DisableEditAndDeleteButtons()
        {
            DeleteButton.IsEnabled = false;
            EditButton.IsEnabled = false;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)UserListView.SelectedItem;
            NameTextBox.Text = selectedUser.Name;
            SurnameTextxBox.Text = selectedUser.Surname;
            LoginTextBox.Text = selectedUser.Login;
            PasswordTextBox.Text = selectedUser.Password;
            PositionTextBox.Text = selectedUser.Position;
            RequestButton.Visibility = Visibility.Collapsed;
            UpdateButton.Visibility = Visibility.Visible;
            RequestGrid.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)UserListView.SelectedItem;
            selectedUser.Name = NameTextBox.Text;
            selectedUser.Surname = SurnameTextxBox.Text;
            selectedUser.Position = PositionTextBox.Text;
            selectedUser.Password = PasswordTextBox.Text;
            selectedUser.Login = LoginTextBox.Text;

            int index = UserListView.SelectedIndex;
            Users.RemoveAt(index);
            Users.Insert(index, selectedUser);

            UserRepository.UpdateUser(selectedUser);
            LogService.AddLog(selectedUser, LogEvent.UPDATE);
            Logs.Add(LogRepository.GetLast());
        }
    }
}
