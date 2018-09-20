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

        private void EditUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
