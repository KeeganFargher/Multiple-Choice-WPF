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
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow
    {
        private readonly List<RadioButton> _radioButtons = new List<RadioButton>();

        private readonly List<Question> _questions;

        private readonly int[] _userAnswers;

        private readonly int _testId;

        private readonly int _userId;

        private int _questionIndex;

        public TestWindow(int userId, int testId)
        {
            InitializeComponent();
            _testId = testId;
            _userId = userId;
            _userAnswers = new int[TestController.GetTestSize(testId)];
            _questions = TestController.GetQuestions(testId);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TestName.Text = TestController.GetTestName(_testId);
            UpdateText();
            Previous.IsEnabled = false;

            _radioButtons.Add(ChoiceA);
            _radioButtons.Add(ChoiceB);
            _radioButtons.Add(ChoiceC);
            _radioButtons.Add(ChoiceD);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            //  Go to the next question
            _questionIndex++;

            //  Reloads the user's answer
            int usersAnswer = _userAnswers[_questionIndex];
            _radioButtons[usersAnswer].IsChecked = true;

            //  Enable the previous button if you go to the next question
            Previous.IsEnabled = true;

            UpdateText();

            //  Show the submit button if you are on the last question
            if (_questionIndex == TestController.GetTestSize(_testId) - 1)
            {
                Submit.Visibility = Visibility.Visible;
                Next.Visibility = Visibility.Hidden;
            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            //  Go back to the previous question
            _questionIndex--;

            //  Reloads the user's answer
            int usersAnswer = _userAnswers[_questionIndex];
            _radioButtons[usersAnswer].IsChecked = true;

            //  Disable previous button if there is no previous question
            if (_questionIndex == 0) { Previous.IsEnabled = false; }

            Next.Visibility = Visibility.Visible;
            Submit.Visibility = Visibility.Hidden;

            UpdateText();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            await StudentController.SubmitUsersAnswersAsync(_userId, _testId, _userAnswers.ToList());
            ShowMemoConfirmation();
        }

        private void UpdateText()
        {
            //  Updates question number
            QuestionNumber.Text = $@"Question {_questionIndex + 1} " +
                                            $"of {TestController.GetTestSize(_testId)}";

            Points.Text = $"{_questions[_questionIndex].Points} Points";

            //  Updates question text
            QuestionText.Text = _questions[_questionIndex].Question_Text;

            //  Updates choices
            ChoiceA.Content = $"A.  {_questions[_questionIndex].ChoiceA}";
            ChoiceB.Content = $"B.  {_questions[_questionIndex].ChoiceB}";
            ChoiceC.Content = $"C.  {_questions[_questionIndex].ChoiceC}";
            ChoiceD.Content = $"D.  {_questions[_questionIndex].ChoiceD}";
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button.IsChecked != true) { return; }

            int index = _radioButtons.IndexOf(button);
            _userAnswers[_questionIndex] = index;
        }

        private void ShowMemoConfirmation()
        {
            int mark = StudentController.GetMark(_userId, _testId);
            int testTotal = TestController.GetTotalMarks(_testId);
            string message =
                $"Your final mark for the test is: {mark} / {testTotal}\n" +
                $"Would you like the view the memo for this test?";

            MessageBoxResult result = MessageBox.Show(message, "Your Results", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                ShowMemo();
            }
        }

        private void ShowMemo()
        {
            MemoWindow memo = new MemoWindow(_testId, _userId);
            memo.Show();
            Close();
        }
    }
}
