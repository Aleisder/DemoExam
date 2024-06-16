using DemoExam.Repository;
using DemoExam.View;
using System.Windows;

namespace DemoExam
{
    public partial class AuthorizationScreen : Window
    {
        private readonly UserRepository userRepository = new();
        public AuthorizationScreen() => InitializeComponent();
 
        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Password;

            if (login == "" || password == "")
            {
                errorText.Text = "Не все поля заполнены";
                errorText.Visibility = Visibility.Visible;
            }

            var user = userRepository.Validate(login, password);
            if (userRepository.Validate(login, password))
            {

                ManagerScreen managerScreen = new(userRepository.GetByLogin(login).Id);
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
