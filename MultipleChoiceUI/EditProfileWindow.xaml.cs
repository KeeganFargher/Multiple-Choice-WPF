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
using System.Windows.Shapes;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private readonly int _userId;

        public EditProfileWindow(int id)
        {
            InitializeComponent();
            _userId = id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Name.Text = UserController.GetFirstName(_userId);
            Surname.Text = UserController.GetSurname(_userId);
            Password.Text = UserController.GetPassword(_userId);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            StudentMenuWindow studentMenu = new StudentMenuWindow(_userId);
            studentMenu.Show();
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            UserController.SetFirstName(_userId, Name.Text);
            UserController.SetSurname(_userId, Surname.Text);
            UserController.SetPassword(_userId, Password.Text);

            StudentMenuWindow studentMenu = new StudentMenuWindow(_userId);
            studentMenu.Show();
            Close();
        }
    }
}
