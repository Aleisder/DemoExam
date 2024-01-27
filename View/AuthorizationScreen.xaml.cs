using DemoExam.Repository;
using DemoExam.View;
using System.Windows;

namespace DemoExam
{
    public partial class AuthorizationScreen : Window
    {
        private readonly UserRepository userRepository = new();

        public AuthorizationScreen()
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
