using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data.Entity;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MultipleChoiceLibrary;
using MultipleChoiceLibrary.Models;
using MultipleChoiceUI.Properties.DataSources;
using MultipleChoiceUI.Properties.DataSources.DataSetMarkTableAdapters;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for ViewMarksWindow.xaml
    /// </summary>
    public partial class ViewMarksWindow : Window
    {
        private int _testId;
        private int _userId;

        public ViewMarksWindow(int testId, int userId)
        {
            InitializeComponent();
            _testId = testId;
            _userId = userId;
        }

        public ViewMarksWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //  Create a database object
            MultipleChoiceEntities multipleChoice = new MultipleChoiceEntities();

            //  Add the relevant information to the markModels list
            var mark = multipleChoice.Marks.Where(x => x.Test_ID == _testId).ToList();
            List<MarkModel> markModels = 
                mark.Select(t => new MarkModel
                {
                    Name = t.User.Name,
                    Surname = t.User.Surname,
                    Mark = t.User_Mark
                }).ToList();

            //  Set the item source to the markModels list
            DataGrid.ItemsSource = markModels;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            LectureMenuWindow lectureMenu = new LectureMenuWindow(_userId);
            lectureMenu.Show();
            Close();;
        }
    }


}
