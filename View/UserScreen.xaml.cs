using DemoExam.Model;
using DemoExam.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DemoExam.View
{
    public partial class ManagerScreen : Window
    {
        private string Login;

        private readonly UserRepository userRepository = new();
        private readonly LogRepository logRepository = new();

        private readonly List<TextBox> TextFields;

        public ManagerScreen(string login)
        {
            this.Login = login;
            InitializeComponent();

            userRepository.GetAll().ForEach(user => { UserBoxList.Items.Add(user); });
            logRepository.GetAll().ForEach(log => { LogListView.Items.Add(log); });

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

        private void OpenAddUserWindow() => RequestGrid.Visibility = Visibility.Visible;

        private void ClearTextBoxes() => TextFields.ForEach(x => x.Clear());

        private void ConfirmUserClick(object sender, RoutedEventArgs e)
        {
            var user = new User(0, SurnameTextxBox.Text, NameTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, PositionTextBox.Text);
            userRepository.AddUser(user);
            CloseAddUserWindow();
            ClearTextBoxes();
            UserBoxList.Items.Add(user);
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            MessageBox.Show("CLicked");

        }

        private void ExitClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из учётной записи?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var screen = new AuthorizationScreen();
                screen.Show();
                Close();
            }
        }
    }
}
