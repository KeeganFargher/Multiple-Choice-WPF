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
using MultipleChoiceUI.User_Controls;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for MemoWindow.xaml
    /// </summary>
    public partial class MemoWindow : Window
    {
        private readonly int _testId;
        private readonly int _userId;

        public MemoWindow(int testID, int userID)
        {
            InitializeComponent();
            _testId = testID;
            _userId = userID;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //  Display mark
            Mark.Text = $"Mark: {StudentController.GetMark(_userId, _testId)} / {TestController.GetTotalMarks(_testId)}";

            //  Get the test name and questions
            TestName.Text = TestController.GetTestName(_testId);
            var questions = TestController.GetQuestions(_testId);

            //  Loop through all the questions
            for (int i = 0; i < questions.Count; i++)
            {
                //  Initialize each control with the question and answers
                MemoUserControl memo = new MemoUserControl();
                memo.InitControls(questions[i], i);
                int correctAnswer = questions[i].Answer;
                int wrongAnswer = StudentController.GetUserAnswerAtIndex(_userId, questions[i].Question_ID);
                memo.HighlightAnswers(correctAnswer, wrongAnswer);

                //  Add the control to the grid
                Grid.SetRow(memo, i);
                memo.Margin = new Thickness(0, 0, 20, 20);
                GridControl.RowDefinitions.Add(new RowDefinition());
                GridControl.Children.Add(memo);
            }
        }

        private void ReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            StudentMenuWindow studentMenu = new StudentMenuWindow(_userId);
            studentMenu.Show();
            Close();
        }
    }
}
