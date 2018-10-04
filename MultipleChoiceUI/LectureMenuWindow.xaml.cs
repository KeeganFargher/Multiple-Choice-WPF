using System.Windows;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for LectureMenuWindow.xaml
    /// </summary>
    public partial class LectureMenuWindow : Window
    {
        private int _userId;

        public LectureMenuWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            Welcome.Text = $"Welcome {UserController.GetFirstName(_userId)}!";
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            CreateTestWindow createTest = new CreateTestWindow(_userId);
            createTest.Show();
            Close();
        }

        private async void EditTest_Click(object sender, RoutedEventArgs e)
        {
            var tests = await TestController.GetAllTestsAsync();

            // Ask the user what test they want to edit
            TestSelectionWindow testSelection = new TestSelectionWindow();
            testSelection.PopulateComboBox(tests);
            testSelection.Owner = this;
            Effect = Utility.Blur;
            testSelection.ShowDialog();

            if (testSelection.DialogResult == true)
            {
                CreateTestWindow test = new CreateTestWindow(testSelection.SelectedValue, _userId);
                test.Show();
                Close();
            }
        }

        private async void ViewMarks_Click(object sender, RoutedEventArgs e)
        {
            var tests = await TestController.GetAllTestsAsync();

            // Ask the user what test they want to edit
            TestSelectionWindow testSelection = new TestSelectionWindow();
            testSelection.PopulateComboBox(tests);
            testSelection.Owner = this;
            Effect = Utility.Blur;
            testSelection.ShowDialog();

            if (testSelection.DialogResult == true)
            {
                ViewMarksWindow viewMarks = new ViewMarksWindow(testSelection.SelectedValue, _userId);
                viewMarks.Show();
                Close();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
    }
}
