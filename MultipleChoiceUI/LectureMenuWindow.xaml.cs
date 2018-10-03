using System.Windows;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for LectureMenuWindow.xaml
    /// </summary>
    public partial class LectureMenuWindow : Window
    {
        public LectureMenuWindow()
        {
            InitializeComponent();
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            CreateTestWindow createTest = new CreateTestWindow();
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
                CreateTestWindow test = new CreateTestWindow(testSelection.SelectedValue);
                test.Show();
                Close();
            }
        }

        private void ViewMarks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
    }
}
