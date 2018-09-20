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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
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

            if (testSelection.DialogResult == true)
            {
                TestWindow test = new TestWindow(_userId, testSelection.SelectedValue);
                test.Show();
                Close();
            }
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

            if (testSelection.DialogResult == true)
            {
                MemoWindow memo = new MemoWindow(testSelection.SelectedValue, _userId);
                memo.Show();
                Close();
            }
        }

        private void ButtonEditProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
