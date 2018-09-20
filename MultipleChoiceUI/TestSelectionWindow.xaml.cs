using System.Collections.Generic;
using System.Windows;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for TestSelectionUserControl.xaml
    /// </summary>
    public partial class TestSelectionWindow
    {
        public int SelectedValue { get; private set; } = -1;

        public TestSelectionWindow()
        {
            InitializeComponent();
        }

        public void PopulateComboBox(List<Test> tests)
        {
            ComboBoxItems.Items.Clear();

            //  Display message if no tests are available
            if (tests.Count == 0)
            {
                ComboBoxItems.Items.Add("No Tests Available");
                ComboBoxItems.SelectedIndex = 0;
                Accept.IsEnabled = false;
                return;
            }

            ComboBoxItems.ItemsSource = tests;
            ComboBoxItems.DisplayMemberPath = "Name";
            ComboBoxItems.SelectedValuePath = "Test_ID";
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            SelectedValue = (int)ComboBoxItems.SelectedValue;
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
    }
}
