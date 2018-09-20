using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI.User_Controls
{
    /// <summary>
    /// Interaction logic for MemoUserControl.xaml
    /// </summary>
    public partial class MemoUserControl
    {
        public MemoUserControl()
        {
            InitializeComponent();
        }

        public void InitControls(Question question, int index)
        {
            QuestionNumber.Text = $"Question {index + 1}";
            Points.Text = $"{question.Points} Points";
            Question.Text = question.Question_Text;
            ChoiceA.Text = $"A. \t{question.ChoiceA}";
            ChoiceB.Text = $"B. \t{question.ChoiceB}";
            ChoiceC.Text = $"C. \t{question.ChoiceC}";
            ChoiceD.Text = $"D. \t{question.ChoiceD}";
        }

        /// <summary>
        /// Highlights the answers by setting the back colour of the text block
        /// </summary>
        /// <param name="correctAnswer">The correct answer</param>
        /// <param name="userAnswer">The user's answer</param>
        public void HighlightAnswers(int correctAnswer, int userAnswer)
        {
            List<TextBlock> choices = new List<TextBlock>
            {
                ChoiceA, ChoiceB, ChoiceC, ChoiceD
            };

            //  Highlights the student's answer as a green label if the answer they picked
            //  was correct, otherwise it highlights the correct in answer in red to indicate
            //  the user selected the wrong answer.
            Brush backColor = correctAnswer == userAnswer ? Utility.CorrectAnswer : Utility.IncorrectAnswer;
            SetLabelComponents(backColor, userAnswer, choices);

            //  Displays the correct answer below the main memo
            CorrectAnswer.Text = choices[correctAnswer].Text;
        }

        /// <summary>
        /// Initializes the label's components
        /// </summary>
        /// <param name="backColor">The background colour of the label</param>
        /// <param name="index">The index of the label to highlight</param>
        /// <param name="choices">The array of labels</param>
        private static void SetLabelComponents(Brush backColor, int index, IReadOnlyList<TextBlock> choices)
        {
            choices[index].Background = backColor;
            choices[index].FontWeight = FontWeights.Bold;
        }
    }
}
