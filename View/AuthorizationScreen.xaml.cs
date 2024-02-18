﻿using DemoExam.Configuration;
using DemoExam.Repository;
using DemoExam.View;
using System.Linq;
using System.Windows;

namespace DemoExam
{
    public partial class AuthorizationScreen : Window
    {
        public AuthorizationScreen() => InitializeComponent();

        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Text;

            if (login == "" || password == "")
            {
                errorText.Text = "Не все поля заполнены";
                errorText.Visibility = Visibility.Visible;
            }

            else if (UserRepository.ValidateUser(login, password))
            {
                LogRepository.AddLog("AuthorizationScreen", string.Format("Logged into account with login '{0}'", login));
                ManagerScreen managerScreen = new("sdf");
                managerScreen.Show();
                Close();
            }
            else
            {
                ClearInputFields();
                errorText.Text = "Неверный логин или пароль";
                errorText.Visibility = Visibility.Visible;
            }

        }

        public void ClearInputFields()
        {
            loginField.Clear();
            passwordField.Clear();
        }
    }
}
