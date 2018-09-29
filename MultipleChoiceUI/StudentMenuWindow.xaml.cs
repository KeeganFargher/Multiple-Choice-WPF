using System.Windows;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for StudentMenuWindow.xaml
    /// </summary>
    public partial class StudentMenuWindow
    {
        private readonly int _userId;

        public StudentMenuWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        public StudentMenuWindow()
        {
            InitializeComponent();
        }

        private async void ButtonStartTest_Click(object sender, RoutedEventArgs e)
        {
            var tests = await StudentController.GetTestsUserHasNotWrittenAsync(_userId);

            // Ask the student what test they want to write
            TestSelectionWindow testSelection = new TestSelectionWindow();
            testSelection.PopulateComboBox(tests);
            testSelection.Owner = this;
            Effect = Utility.Blur;
            testSelection.ShowDialog();

            //  Open the test window
            if (testSelection.DialogResult != true) return;
            TestWindow test = new TestWindow(_userId, testSelection.SelectedValue);
            test.Show();
            Close();
        }

        private async void ButtonViewMemo_Click(object sender, RoutedEventArgs e)
        {
            var tests = await StudentController.GetTestsUserHasWrittenAsync(_userId);

            // Ask the student what test they want to view
            TestSelectionWindow testSelection = new TestSelectionWindow();
            testSelection.PopulateComboBox(tests);
            testSelection.Owner = this;
            Effect = Utility.Blur;
            testSelection.ShowDialog();

            //  Display the memo
            if (testSelection.DialogResult != true) return;
            MemoWindow memo = new MemoWindow(testSelection.SelectedValue, _userId);
            memo.Show();
            Close();
        }

        private void ButtonEditProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
