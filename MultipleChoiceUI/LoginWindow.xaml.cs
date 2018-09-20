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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void ButtonLogin_ClickAsync(object sender, RoutedEventArgs e)
        {
            bool result = int.TryParse(TextBoxUsername.Text, out int username);
            string password = TextBoxPassword.Password;

            bool works = await UserController.CredentialsMatchAsync(Convert.ToInt32(username), password);

            if (!works || !result) return;

            User user = UserController.GetUser(username);

            if (user.Type == "Student")
            {
                StudentMenuWindow studentMenu = new StudentMenuWindow(user.User_ID);
                studentMenu.Show();
                Close();
            }
            else
            {
                LectureMenuWindow lectureMenu = new LectureMenuWindow();
                lectureMenu.Show();
                Close();
            }
        }
    }
}
