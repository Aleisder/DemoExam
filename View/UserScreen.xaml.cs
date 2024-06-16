using DemoExam.Configuration;
using DemoExam.Enums;
using DemoExam.Model.Archive;
using DemoExam.Model.UserPool;
using DemoExam.Repository;
using DemoExam.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoExam.View
{
    public partial class ManagerScreen : Window
    {
        private readonly UserService userService;
        private readonly LogService logService = new();
        private readonly User CurrentUser;

        public ManagerScreen(int userId)
        {
            InitializeComponent();
            userService = new();
            CurrentUser = userService.GetById(userId);

            InfoTextBox.Text = StaticData.Info;
            SetUpUserInfo();
            LoadRoleComboBox();
            logService.Add(CurrentUser, LogEvent.LOG_IN);

            UserDataGrid.ItemsSource = userService.users;
            UserListView.Visibility = Visibility.Collapsed;

            //UserListView.ItemsSource = userService.users;
            LogListView.ItemsSource = logService.logs;
        }

        private void SetUpUserInfo()
        {
            UserNameTextBlock.Text = CurrentUser.ToString();
            UserPositionTextBlock.Text = CurrentUser.Role.Name;
        }

        private void SetUpRole(Role role)
        {
            switch (role.Name)
            {

            }

        }

        private void LoadRoleComboBox() => RoleComboBox.ItemsSource = userService.GetRoles();

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
            RoleComboBox.Text = "";
        }

        private void ConfirmUserClick(object sender, RoutedEventArgs e)
        {
            var role = (Role)RoleComboBox.SelectedItem;

            var user = new User(
                NameTextBox.Text.Trim(),
                SurnameTextxBox.Text.Trim(),
                LoginTextBox.Text.Trim(),
                PasswordTextBox.Text.Trim(),
                role
            );

            userService.Add(user);
            logService.Add(user, LogEvent.CREATE);
            CloseAddUserWindow();
            ClearTextBoxes();
        }

        private void ExitClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из учётной записи?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                logService.Add(CurrentUser, LogEvent.LOG_OUT);
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
                User user = userService.users.ElementAt(index);
                if (user != null)
                {
                    userService.Delete(user);
                    logService.Add(user, LogEvent.DELETE);
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
            RoleComboBox.SelectedItem = selectedUser.Role;
            RequestButton.Visibility = Visibility.Collapsed;
            UpdateButton.Visibility = Visibility.Visible;
            RequestGrid.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)UserListView.SelectedItem;
            selectedUser.Name = NameTextBox.Text;
            selectedUser.Surname = SurnameTextxBox.Text;
            selectedUser.Password = PasswordTextBox.Text;
            selectedUser.Login = LoginTextBox.Text;
            selectedUser.Role = (Role)RoleComboBox.SelectedItem;

            int index = UserListView.SelectedIndex;

            userService.Update(index, selectedUser);
            logService.Add(selectedUser, LogEvent.UPDATE);

            CloseAddUserWindow();
        }

        private void ArchiveListViewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //var index = ArchiveListView.SelectedIndex;

            //switch (CurrentChapter)
            //{
            //    case Chapter.ACT:
            //        ActDto act = (ActDto)ArchiveListView.Items.GetItemAt(index);
            //        LastVisitedVolumeId = act.Id;
            //        List<CaseDto> cases = ArchiveService.GetCasesByActId(act.Id);
            //        ArchiveListView.ItemTemplate = (DataTemplate)Resources["CaseListItem"];
            //        ArchiveListView.ItemsSource = cases;
            //        CurrentChapter = Chapter.CASE;
            //        break;

            //    case Chapter.CASE:
            //        Case caseItem = (Case)ArchiveListView.Items.GetItemAt(index);
            //        OfficeService.CreateDocument(caseItem);
            //        break;

            //    default:
            //        VolumeDto item = (VolumeDto)ArchiveListView.Items.GetItemAt(index);
            //        Volume volume = ArchiveRepository.GetVolumeByName(item.Name);
            //        List<ActDto> acts = ArchiveService.GetActsByVolumeId(volume.Id);
            //        ArchiveListView.ItemTemplate = (DataTemplate)Resources["ActListItem"];
            //        ArchiveListView.ItemsSource = acts;
            //        CurrentChapter = Chapter.ACT;
            //        break;
            //}

        }

        private void CreateVolumeConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string name = VolumeNameTextBox.Text;
            ArchiveService.AddVolume(name);
            //ArchiveListView.ItemsSource = ArchiveService.GetVolumes();
            CloseCreateVolumeDialog();
        }

        private void CloseCreateVolumeDialog()
        {
            VolumeNameTextBox.Clear();
            CreateVolumeGrid.Visibility = Visibility.Collapsed;
        }

        private void CloseCreateVolumeGridClick(object sender, RoutedEventArgs e) => CloseCreateVolumeDialog();

        private void CreateVolumeButton_Click(object sender, RoutedEventArgs e)
        {
            CreateVolumeGrid.Visibility = Visibility.Visible;
        }

        private void CreateActButton_Click(object sender, RoutedEventArgs e)
        {
            CreateActGrid.Visibility = Visibility.Visible;
            LoadVolumeComboBoxItems();

        }

        private void LoadVolumeComboBoxItems()
        {
            //ArchiveRepository.GetVolumes().ForEach(volume => VolumeComboBox.Items.Add(volume.Name));
        }

        private void CreateActConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            string actName = ActNameTextBox.Text;
            string parentVolumeName = VolumeComboBox.Text;
            if (ArchiveRepository.ActExistsByName(actName, parentVolumeName))
            {
                MessageBox.Show("Акт с таким названием уже существует в данном томе");
            }
            else
            {
                Volume parentVolume = ArchiveRepository.GetByName(parentVolumeName);
                ArchiveRepository.AddAct(actName, parentVolume.Id);
                CloseCreateAct();
            }
        }

        private void HelpButtonClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => HelpGrid.Visibility = Visibility.Visible;

        private void CloseHelpGrid(object sender, RoutedEventArgs e) => HelpGrid.Visibility = Visibility.Collapsed;

        private void CloseCreateActClick(object sender, RoutedEventArgs e) => CloseCreateAct();

        private void CloseCreateAct()
        {
            ActNameTextBox.Clear();
            VolumeComboBox.Items.Clear();
            CreateActGrid.Visibility = Visibility.Collapsed;
        }

        private void CloseCreateCase()
        {
            CreateCaseGrid.Visibility = Visibility.Collapsed;
            CaseNameTextBox.Clear();
            CaseIntruderTextBox.Clear();

        }

        private void CloseCreateCaseClick(object sender, RoutedEventArgs e) => CloseCreateCase();

        private void CaseVolumeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                Volume selectedVolume = ArchiveRepository.GetVolumeByName(e.AddedItems[0].ToString());
                CaseActComboBox.Items.Clear();
                ArchiveRepository.GetActsByVolumeId(selectedVolume.Id).ForEach(x => CaseActComboBox.Items.Add(x));
            }
            else
            {
                CaseActComboBox.Items.Clear();
            }
        }

        private void OpenCreateCaseWindow()
        {
            //CreateCaseGrid.Visibility = Visibility.Visible;

            //CaseVolumeComboBox.Items.Clear();
            //ArchiveRepository.GetVolumes().ForEach(x => CaseVolumeComboBox.Items.Add(x.Name));

            //SectionComboBox.Items.Clear();
            //SectionRepository.GetSections().ForEach(x => SectionComboBox.Items.Add(x));

            //InvestigatorComboBox.Items.Clear();
            //UserRepository.GetInvestigators().ForEach(x => InvestigatorComboBox.Items.Add(x));
        }

        private void CreateCaseButtonClick(object sender, RoutedEventArgs e) => OpenCreateCaseWindow();

        private void ArchiveBackButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void CreateCaseConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            //Act parentAct = (Act)CaseActComboBox.SelectedItem;
            //string name = CaseNameTextBox.Text;
            //string intruder = CaseIntruderTextBox.Text;
            //User investigator = (User)InvestigatorComboBox.SelectedItem;
            //Section section = (Section)SectionComboBox.SelectedItem;
            //string evidence = EvidenceTextBox.Text;

            //Case newCase = new Case(parentAct.Id, name, intruder, investigator.Id, section.Id, evidence);

            //ArchiveRepository.AddCase(newCase);
            //CloseCreateCase();

            //MessageBox.Show("Вы завели новое дело!", "Создание дела");
        }

        private void DeleteVolumeButtonClick(object sender, RoutedEventArgs e)
        {
            //if (ArchiveListView.SelectedItem != null)
            //{
            //    var result = MessageBox.Show("Вы действительно хотите удалить пользователя?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //    if (result == MessageBoxResult.Yes)
            //    {
            //        VolumeDto volumeDto = (VolumeDto)ArchiveListView.SelectedItem;
            //        ArchiveRepository.DeleteVolumeById(volumeDto.Id);
            //        ArchiveListView.ItemsSource = ArchiveService.GetVolumes();
            //    }
            //}
        }

        private void DeleteActButtonClick(object sender, RoutedEventArgs e)
        {
            //if (ArchiveListView.SelectedItem != null)
            //{
            //    var result = MessageBox.Show("Вы действительно хотите удалить акт?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //    if (result == MessageBoxResult.Yes)
            //    {
            //        Act actDto = (Act)ArchiveListView.SelectedItem;
            //        Act act = ArchiveRepository.GetActById(actDto.Id);
            //        ArchiveRepository.DeleteActById(act.Id);
            //        ArchiveListView.ItemsSource = ArchiveService.GetActsByVolumeId(act.VolumeId);
            //    }
            //}
        }

        private void UpdateVolumeButtonClick(object sender, RoutedEventArgs e)
        {
            //Volume volume = (Volume)ArchiveListView.SelectedItem;
            //Volume editedVolume = new Volume(volume.Id, VolumeNameTextBox.Text);
            //ArchiveRepository.UpdateVolume(editedVolume);

            //CreateVolumeGrid.Visibility = Visibility.Collapsed;
            //CreateVolumeButton.Visibility = Visibility.Visible;
            //UpdateVolumeButton.Visibility = Visibility.Collapsed;

            //ArchiveListView.ItemsSource = ArchiveService.GetVolumes();
        }

        private void EditVolumeButtonClick(object sender, RoutedEventArgs e)
        {
            //Volume volume = (Volume)ArchiveListView.SelectedItem;

            //CreateVolumeGrid.Visibility = Visibility.Visible;
            //CreateVolumeButton.Visibility = Visibility.Collapsed;
            //UpdateVolumeButton.Visibility = Visibility.Visible;

            //VolumeNameTextBox.Text = volume.Name;
        }
    }
}
