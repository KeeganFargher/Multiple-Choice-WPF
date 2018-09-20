using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for EditQuestionWindow.xaml
    /// </summary>
    public partial class EditQuestionWindow : Window
    {
        private readonly int questionID;
        private readonly int testID;

        //  Whether we are editing or creating a new question
        private bool isEditMode = false;

        List<RadioButton> radioButtons;

        //  New question
        public EditQuestionWindow(int testID)
        {
            InitializeComponent();

            this.testID = testID;
            InitRadioButtons();
        }

        //  Edit a previously created question
        public EditQuestionWindow(int testID, int questionID)
        {
            InitializeComponent();

            this.testID = testID;
            this.questionID = questionID;
            InitRadioButtons();
            isEditMode = true;
            PopulateText();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (isEditMode)
            {
                SaveEditedChanges();
            }
            else
            {
                SubmitNewQuestion();
            }
            Close();
        }

        private void SaveAddAnother_Click(object sender, RoutedEventArgs e)
        {
            if (isEditMode)
            {
                SaveEditedChanges();
            }
            else
            {
                SubmitNewQuestion();
            }
            ClearFields();
            isEditMode = false;
        }

        /// <summary>
        /// Saves the changes made to the question
        /// </summary>
        private void SaveEditedChanges()
        {
            //  Save question text
            TestController.SetQuestionText(questionID, testID, QuestionText.Text);

            //  Save choices
            TestController.SetChoiceA(questionID, testID, ChoiceA.Text);
            TestController.SetChoiceB(questionID, testID, ChoiceB.Text);
            TestController.SetChoiceC(questionID, testID, ChoiceC.Text);
            TestController.SetChoiceD(questionID, testID, ChoiceD.Text);

            //  Save the correct answer
            int index = radioButtons.IndexOf(radioButtons.FirstOrDefault(x => x.IsChecked == true));
            TestController.SetAnswer(questionID, testID, index);

            //  Save how many points the question is worth
            TestController.SetPoints(questionID, testID, (int)Points.Value);
        }

        /// <summary>
        /// Submits a new question
        /// </summary>
        private void SubmitNewQuestion()
        {
            int answerIndex = radioButtons.IndexOf(radioButtons.FirstOrDefault(x => x.IsChecked == true));

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

            TestController.AddQuestion(question, testID);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditQuestionWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Owner.Effect = null;
        }

        private void PopulateText()
        {
            //  Retrieve the question
            Question question = TestController.GetQuestion(testID, questionID);

            //  Set the question text
            QuestionText.Text = question.Question_Text;

            //  Populate the possible answers
            ChoiceA.Text = question.ChoiceA;
            ChoiceB.Text = question.ChoiceB;
            ChoiceC.Text = question.ChoiceC;
            ChoiceD.Text = question.ChoiceD;
            
            //  Check the correct answer
            radioButtons[question.Answer].IsChecked = true;

            Points.Value = question.Points;
        }

        //  Initializes the radio buttons
        private void InitRadioButtons()
        {
            radioButtons = new List<RadioButton>()
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
            radioButtons[0].IsChecked = true;
            Points.Value = Points.Minimum;
        }
    }
}
