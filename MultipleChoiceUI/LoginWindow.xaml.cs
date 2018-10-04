using System;
using System.Windows;
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

            switch (user.Type)
            {
                case "Student":
                    {
                        StudentMenuWindow studentMenu = new StudentMenuWindow(user.User_ID);
                        studentMenu.Show();
                        Close();
                        break;
                    }
                case "Lecture":
                    {
                        LectureMenuWindow lectureMenu = new LectureMenuWindow(user.User_ID);
                        lectureMenu.Show();
                        Close();
                        break;
                    }
                default:
                    {
                    break;
                    }    
            }
        }
    }
}
