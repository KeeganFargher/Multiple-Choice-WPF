using System.Collections.Generic;
using System.Windows.Controls;
using MultipleChoiceLibrary;

namespace MultipleChoiceUI.User_Controls
{
    /// <summary>
    /// Interaction logic for MemoUserControl.xaml
    /// </summary>
    public partial class QuestionUserControl
    {
        public QuestionUserControl()
        {
            InitializeComponent();
        }

        //  Initializes the controls
        public void InitControls(Question question, int index)
        {
            Header.Text = $@"Q.{index+1} {question.Question_Text}";

            //Points.Text = $@"{question.Points} Point";
            //if (question.Points > 1) { Points.Text += "s"; }

            //Question.Text = question.Question_Text;
            ChoiceA.Text = $"A. \t{question.ChoiceA}";
            ChoiceB.Text = $"B. \t{question.ChoiceB}";
            ChoiceC.Text = $"C. \t{question.ChoiceC}";
            ChoiceD.Text = $"D. \t{question.ChoiceD}";

            var radioButtons = new List<TextBlock>()
            {
                ChoiceA,
                ChoiceB,
                ChoiceC,
                ChoiceD
            };
            radioButtons[question.Answer].Background = Utility.CorrectAnswer;
        }
    }
}
