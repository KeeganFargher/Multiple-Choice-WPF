using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI
{
    /// <summary>
    /// Interaction logic for EditQuestionWindow.xaml
    /// </summary>
    public partial class EditQuestionWindow
    {
        private readonly int _questionId;

        private readonly int _testId;

        //  Whether we are editing or creating a new question
        private bool _isEditMode;

        List<RadioButton> _radioButtons;

        //  New question
        public EditQuestionWindow(int testId)
        {
            InitializeComponent();

            _testId = testId;
            InitRadioButtons();
        }

        //  Edit a previously created question
        public EditQuestionWindow(int testId, int questionId)
        {
            InitializeComponent();

            _testId = testId;
            _questionId = questionId;
            InitRadioButtons();
            _isEditMode = true;
            PopulateText();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (AreEmptyFields())
            {
                MessageBox.Show("Please ensure no fields are empty");
                return;
            }
            SubmitChanges();
            Close();
        }

        private void SaveAddAnother_Click(object sender, RoutedEventArgs e)
        {
            if (AreEmptyFields())
            {
                MessageBox.Show("Please ensure no fields are empty");
                return;
            }
            SubmitChanges();
            ClearFields();
            _isEditMode = false;
        }

        /// <summary>
        /// Submits the changes made
        /// </summary>
        private void SubmitChanges()
        {
            if (_isEditMode)
            {
                SaveEditedChanges();
            }
            else
            {
                SubmitNewQuestion();
            }
        }

        /// <summary>
        /// Saves the changes made to the question
        /// </summary>
        private void SaveEditedChanges()
        {
            //  Save question text
            TestController.SetQuestionText(_questionId, _testId, QuestionText.Text);

            //  Save choices
            TestController.SetChoiceA(_questionId, _testId, ChoiceA.Text);
            TestController.SetChoiceB(_questionId, _testId, ChoiceB.Text);
            TestController.SetChoiceC(_questionId, _testId, ChoiceC.Text);
            TestController.SetChoiceD(_questionId, _testId, ChoiceD.Text);

            //  Save the correct answer
            int index = _radioButtons.IndexOf(_radioButtons.FirstOrDefault(x => x.IsChecked == true));
            TestController.SetAnswer(_questionId, _testId, index);

            //  Save how many points the question is worth
            TestController.SetPoints(_questionId, _testId, (int)Points.Value);
        }

        /// <summary>
        /// Submits a new question
        /// </summary>
        private void SubmitNewQuestion()
        {
            int answerIndex = _radioButtons.IndexOf(_radioButtons.FirstOrDefault(x => x.IsChecked == true));

            Question question = new Question
            {
                Question_Text = QuestionText.Text,
                ChoiceA = ChoiceA.Text,
                ChoiceB = ChoiceB.Text,
                ChoiceC = ChoiceC.Text,
                ChoiceD = ChoiceD.Text,
                Answer = answerIndex,
                Points = (int)Points.Value
            };

            TestController.AddQuestion(question, _testId);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditQuestionWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Owner.Effect = null;
            Owner.Opacity = 1;
        }

        private void PopulateText()
        {
            //  Retrieve the question
            Question question = TestController.GetQuestion(_testId, _questionId);

            //  Set the question text
            QuestionText.Text = question.Question_Text;

            //  Populate the possible answers
            ChoiceA.Text = question.ChoiceA;
            ChoiceB.Text = question.ChoiceB;
            ChoiceC.Text = question.ChoiceC;
            ChoiceD.Text = question.ChoiceD;
            
            //  Check the correct answer
            _radioButtons[question.Answer].IsChecked = true;

            Points.Value = question.Points;
        }

        //  Initializes the radio buttons
        private void InitRadioButtons()
        {
            _radioButtons = new List<RadioButton>()
            {
                RadioButtonA,
                RadioButtonB,
                RadioButtonC,
                RadioButtonD
            };
        }

        //  Clears the fields
        private void ClearFields()
        {
            QuestionText.Text = "";
            ChoiceA.Text = "";
            ChoiceB.Text = "";
            ChoiceC.Text = "";
            ChoiceD.Text = "";
            _radioButtons[0].IsChecked = true;
            Points.Value = Points.Minimum;
        }

        private bool AreEmptyFields()
        {
            return QuestionText.Text == "" ||
                   ChoiceA.Text == "" ||
                   ChoiceB.Text == "" ||
                   ChoiceC.Text == "" ||
                   ChoiceD.Text == "";
        }
    }
}
