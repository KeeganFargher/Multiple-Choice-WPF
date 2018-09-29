using System.Windows;
using System.Windows.Controls;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for SubmitTest.xaml
    /// </summary>
    public partial class SubmitTestWindow
    {
        public string SelectedTestName { get; set; }

        public SubmitTestWindow()
        {
            InitializeComponent();
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            SelectedTestName = TestName.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Effect = null;
        }

        private void TestName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Accept.IsEnabled = TestName.Text != "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TestName.Text = SelectedTestName;
        }
    }
}
