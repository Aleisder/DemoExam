using DemoExam.Model;
using DemoExam.Repository;
using QRCoder;
using QRCoder.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DemoExam
{
    public partial class UserScreen : Window
    {

        public readonly QRCodeGenerator QRCodeGenerator = new();

        public UserScreen()
        {
            InitializeComponent();
        }

        public UserScreen(string login)
        {
            InitializeComponent();

            var user = userRepository.GetUserByLogin(login);
            TextBlockUserName.Text = user.Surname + " " + user.Name;



            this.Login = login;
            fields.Add(modelField);
            fields.Add(typeField);
            fields.Add(descriptionField);
        }

        private string Login;
        private readonly RequestRepository requestRepository = new();
        private readonly UserRepository userRepository = new();
        private List<TextBox> fields = new();

        private void MakeRequestButtonClick(object sender, RoutedEventArgs e)
        {
            if (gridRequest.Visibility == Visibility.Visible)
                gridRequest.Visibility = Visibility.Collapsed;
            else
                gridRequest.Visibility = Visibility.Visible;
        }

        private void CloseRequestGridClick(object sender, RoutedEventArgs e)
        {
            CloseRequestGrid();
        }

        private void CloseRequestGrid()
        {
            gridRequest.Visibility = Visibility.Collapsed;
            ClearInputField();

        }

        private void SendRequestClick(object sender, RoutedEventArgs e)
        {
            if (ValidateRequestFields())
            {
                User user = userRepository.GetUserByLogin(Login);


                var request = new Request(
                    modelField.Text,
                    Type.BrokenDisplay,
                    descriptionField.Text,
                    user
                );
                requestRepository.AddRequest(request);
                CloseRequestGrid();
                MessageBox.Show("Заявка отправлена!");
                UpdateGrid(user.Id);
            }


        }

        private bool ValidateRequestFields()
        {
            return fields.All(field => field.Text.Length != 0);
        }

        private void ClearInputField()
        {
            foreach (var field in fields)
            {
                field.Text = string.Empty;
            }
        }

        private void UpdateGrid(int id)
        {
            requestDataGrid.ItemsSource = requestRepository.GetRequestsByUserId(id);
            requestDataGrid.Columns[4].Visibility = Visibility.Collapsed;
        }

        private void GenerateQrCode(object sender, RoutedEventArgs e)
        {
            QRCodeData data = QRCodeGenerator.CreateQrCode("adfadfaf", QRCodeGenerator.ECCLevel.Q);
            XamlQRCode qrCode = new XamlQRCode(data);
            DrawingImage qrCodeAsXaml = qrCode.GetGraphic(20);

            gridQrCode.Visibility = Visibility.Visible;
            ImageQrCode.Source = qrCodeAsXaml;

        }
    }
}
