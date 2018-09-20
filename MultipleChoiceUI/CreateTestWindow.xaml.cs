using System;
using System.Windows;
using System.Windows.Controls;
using MultipleChoiceLibrary;
using MultipleChoiceUI.User_Controls;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for CreateTestWindow.xaml
    /// </summary>
    public partial class CreateTestWindow
    {
        private readonly int _testId;

        public CreateTestWindow()
        {
            InitializeComponent();

            Test test = new Test { Name = "" };
            TestController.AddTest(test);
            _testId = test.Test_ID;
        }

        //  If we are editing a test we need the test ID
        public CreateTestWindow(int testId)
        {
            InitializeComponent();
            _testId = testId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshQuestions();
        }

        /// <summary>
        /// Refreshes all the question user controls
        /// </summary>
        private void RefreshQuestions()
        {
            StackPanel.Children.Clear();

            var questions = TestController.GetQuestions(_testId);
            for (int i = 0; i < questions.Count; i++)
            {
                QuestionUserControl question = GetUserControl(questions[i], i);
                StackPanel.Children.Add(question);
            }
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            EditQuestionWindow editQuestion = new EditQuestionWindow(_testId);
            editQuestion.Owner = this;
            editQuestion.Effect = Utility.DropShadowEffect;

            Effect = Utility.Blur;
            editQuestion.ShowDialog();
            RefreshQuestions();
        }

        private void SubmitTest_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Creates a new user control
        /// </summary>
        /// <param name="question">The question to add to the user control</param>
        /// <param name="i">The question number</param>
        private QuestionUserControl GetUserControl(Question question, int i)
        {
            QuestionUserControl questionUserControl = new QuestionUserControl();

            //  Initialize the controls
            questionUserControl.InitControls(question, i);

            //  Subscribe the edit and delete button to the button click event
            questionUserControl.Edit.Click += Button_Click_Edit;
            questionUserControl.Edit.Tag = question.Question_ID;

            questionUserControl.Delete.Click += Button_Click_Delete;
            questionUserControl.Delete.Tag = question.Question_ID;

            return questionUserControl;
        }

        /// <summary>
        /// Called when the edit button is clicked
        /// </summary>
        private void Button_Click_Edit(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button?.Tag == null) return;

            int questionId = (int)button.Tag;

            LoadEditQuestionForm(questionId);
        }

        /// <summary>
        /// Called when the delete button is clicked
        /// </summary>
        private void Button_Click_Delete(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button?.Tag == null) return;

            int questionId = (int)button.Tag;

            MessageBoxResult dialogResult = MessageBox.Show(
                "Are You Sure?",
                "Delete Question",
                MessageBoxButton.YesNo);

            if (dialogResult != MessageBoxResult.Yes) return;

            TestController.RemoveQuestion(questionId);
            RefreshQuestions();
        }

        /// <summary>
        /// Loads the form to edit the question that the user requested
        /// </summary>
        private void LoadEditQuestionForm(int questionId)
        {
            EditQuestionWindow editQuestion = new EditQuestionWindow(_testId, questionId);
            editQuestion.Owner = this;
            editQuestion.Effect = Utility.DropShadowEffect;

            Effect = Utility.Blur;
            editQuestion.ShowDialog();
            RefreshQuestions();
        }

        private void ExpandAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < StackPanel.Children.Count; i++)
            {
                if (StackPanel.Children[i] is QuestionUserControl userControl)
                {
                    userControl.Expander.IsExpanded = true;
                }
            }
        }

        private void CollapseAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < StackPanel.Children.Count; i++)
            {
                if (StackPanel.Children[i] is QuestionUserControl userControl)
                {
                    userControl.Expander.IsExpanded = false;
                }
            }
        }
    }
}
