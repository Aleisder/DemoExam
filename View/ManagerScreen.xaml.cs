using DemoExam.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemoExam.View
{
    public partial class ManagerScreen : Window
    {
        private string Login;

        private readonly ExecutorRepository executorRepository = new();
        private readonly UserRepository userRepository = new();

        private readonly ObservableCollectionListSource<string> Executors = new();

        public ManagerScreen(string login)
        {
            


            InitializeComponent();

            var user = userRepository.GetUserByLogin(login);
            TextBlockUserName.Text = user.Surname + " " + user.Name;


            executorRepository
                .GetFreeExecutors()
                .ForEach(it => Executors.Add(it.Surname + " " + it.Name));

            DataContext = this;



            List<ManagerRequestListItem> list = new();
            list.Add(new ManagerRequestListItem("22346", "Павлов Сергей", "+79855489807", "В РАБОТЕ", "Сергей", "#FF3FD166"));
            list.Add(new ManagerRequestListItem("09820", "Компьютеров Павел", "+79855489807", "В РАБОТЕ", "Сергей", "#FF3FD166"));
            list.Add(new ManagerRequestListItem("69749", "Чайников Илья", "+79855489807", "В РАБОТЕ", "Сергей", "#FF3FD166"));
            list.Add(new ManagerRequestListItem("2345", "Павлов Сергей", "+79855489807", "В РАБОТЕ", "Сергей", "#FF3FD166"));
            list.Add(new ManagerRequestListItem("2345", "Павлов Сергей", "+79855489807", "В РАБОТЕ", "Сергей", "#FF3FD166"));
            list.Add(new ManagerRequestListItem("2345", "Павлов Сергей", "+79855489807", "В РАБОТЕ", "Сергей", "#FF3FD166"));
            RequestsListView.ItemsSource = list;
            Login = login;
        }
    }
}
