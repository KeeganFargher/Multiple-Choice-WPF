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

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for SubmitTest.xaml
    /// </summary>
    public partial class SubmitTestWindow : Window
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
