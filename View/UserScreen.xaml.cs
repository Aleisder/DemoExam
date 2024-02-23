using DemoExam.Enums;
using DemoExam.Model;
using DemoExam.Repository;
using DemoExam.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoExam.View
{
    public partial class ManagerScreen : Window
    {
        private readonly User CurrentUser = new();

        public ManagerScreen(string login)
        {
            InitializeComponent();

            CurrentUser = UserRepository.GetByLogin(login);
            LogService.AddLog(CurrentUser, LogEvent.LOG_IN);

            UserListView.ItemsSource = UserService.Users;
            LogListView.ItemsSource = LogService.Logs;
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

        private void ClearTextBoxes()
        {
            SurnameTextxBox.Clear();
            NameTextBox.Clear();
            LoginTextBox.Clear();
            PasswordTextBox.Clear();
            PositionTextBox.Clear();
        }

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
            UserService.AddUser(user);
            LogService.AddLog(user, LogEvent.CREATE);
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
            var result = MessageBox.Show("Вы действительно хотите удалить пользователя?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                int index = UserListView.SelectedIndex;
                User user = UserService.Users.ElementAt(index);
                if (user != null)
                {
                    UserService.DeleteUser(user);
                    LogService.AddLog(user, LogEvent.DELETE);
                }
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

            UserService.UpdateUser(index, selectedUser);
            LogService.AddLog(selectedUser, LogEvent.UPDATE);

            CloseAddUserWindow();
        }
    }
}
