using DemoExam.Model;
using DemoExam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoExam
{
    public partial class MainWindow : Window
    {
        private readonly UserRepository userRepository = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Text;

            if (login == "" || password == "")
            {
                errorText.Text = "Не все поля заполнены";
                errorText.Visibility = Visibility.Visible;
            }

            else if (userRepository.ValidateUser(login, password))
            {
                User user = userRepository.GetUserByLogin(login);

                switch (user.Role)
                {
                    case Role.Client:
                        {
                            UserScreen userScreen = new(user.Login);
                            userScreen.Show();
                            break;
                        }
                    case Role.Manager:
                        {
                            break;
                        }
                    case Role.Executor:
                        {
                            break;
                        }
                }
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
