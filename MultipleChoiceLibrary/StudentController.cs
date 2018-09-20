using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MultipleChoiceLibrary
{
    public sealed class StudentController : UserController
    {
        /// <summary>
        /// Gets the mark a student got for a test
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <param name="testID">The ID of the test</param>
        /// <returns>The student's mark</returns>
        public static int GetMark(int userID, int testID)
        {
            int mark;

            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                List<Question> questions = multipleChoiceEntities.Tests
                    .FirstOrDefaultAsync(x => x.Test_ID == testID)
                    .Result?.Questions
                    .ToList();

                //  Get all the answers for the specific test the user wrote
                List<Answer> answers = LoadAnswersFromTest(userID, questions);

                //  Calculate user's mark
                mark = CalculateMark(questions, answers);
            }
            return mark;
        }

        /// <summary>
        /// Gets all the tests that the user has already written
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        public static async Task<List<Test>> GetTestsUserHasWrittenAsync(int userID)
        {
            List<Test> writtenTests;
            using (MultipleChoiceEntities multipleChoice = new MultipleChoiceEntities())
            {
                writtenTests = await LoadWrittenTestsAsync(userID, multipleChoice);
            }
            return writtenTests;
        }

        /// <summary>
        /// Gets all the tests that the user has not written
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        public static async Task<List<Test>> GetTestsUserHasNotWrittenAsync(int userID)
        {
            List<Test> unwrittenTests;
            using (MultipleChoiceEntities multipleChoice = new MultipleChoiceEntities())
            {
                //  Loads all the written tests
                var writtenTests = await LoadWrittenTestsAsync(userID, multipleChoice);

                //  Get the tests the student hasn't written
                unwrittenTests = LoadUnwrittenTests(writtenTests, multipleChoice);
            }
            return unwrittenTests;
        }

        /// <summary>
        /// Submits the user's answers
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <param name="testID">The ID of the test</param>
        /// <param name="answers">The list of answers that belongs to the user</param>
        public static async Task SubmitUsersAnswersAsync(int userID, int testID, List<int> answers)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                //  Fetch the questions for the test
                List<Question> questions = await multipleChoiceEntities.Questions
                    .Where(x => x.Test_ID == testID)
                    .ToListAsync();

                //  Submit the test to the DB
                for (int i = 0; i < answers.Count; i++)
                {
                    multipleChoiceEntities.Answers.Add(new Answer()
                    {
                        Question_ID = questions[i].Question_ID,
                        User_ID = userID,
                        User_Answer = answers[i]
                    });
                }
                await multipleChoiceEntities.SaveChangesAsync();

                //  Submit mark
                multipleChoiceEntities.Marks.Add(new Mark()
                {
                    User_ID = userID,
                    Test_ID = testID,
                    User_Mark = GetMark(userID, testID)
                });
                await multipleChoiceEntities.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets the user's answer at a specific index
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <param name="questionID">The ID of the question</param>
        public static int GetUserAnswerAtIndex(int userID, int questionID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Answers
                    .FirstOrDefaultAsync(x => x.User_ID == userID && x.Question_ID == questionID)
                    .Result
                    .User_Answer;
            }
        }

        #region Helper-methods

        /// <summary>
        /// Returns all the answers for the specific test the user wrote
        /// </summary>
        private static List<Answer> LoadAnswersFromTest(int userID, List<Question> questions)
        {
            List<Answer> answers = new List<Answer>();
            foreach (Question question in questions)
            {
                answers.AddRange
                (
                    question
                        .Answers
                        .Where(x => x.User_ID == userID)
                );
            }
            return answers;
        }

        /// <summary>
        /// Calculates the user's mark
        /// </summary>
        private static int CalculateMark(IEnumerable<Question> questions, IReadOnlyList<Answer> answers)
        {
            int mark = 0;
            mark += questions.Where((t, i) => t.Answer == answers[i].User_Answer)
                .Sum(t => t.Points);
            return mark;
        }

        /// <summary>
        /// Returns a list of tests the user has not written
        /// </summary>
        private static async Task<List<Test>> LoadWrittenTestsAsync(int userID, MultipleChoiceEntities multipleChoice)
        {
            List<Test> writtenTests = new List<Test>();

            //  Get all the tests the student has written
            List<Answer> answers = await multipleChoice.Answers
                .Where(x => x.User_ID == userID)
                .ToListAsync();

            //  Add written tests to a list
            foreach (Answer answer in answers)
            {
                if (!writtenTests.Contains(answer.Question.Test))
                {
                    writtenTests.Add(answer.Question.Test);
                }
            }
            return writtenTests;
        }

        /// <summary>
        /// Returns a list of tests the user has not written
        /// </summary>
        private static List<Test> LoadUnwrittenTests(
            IEnumerable<Test> writtenTests, MultipleChoiceEntities multipleChoice)
        {
            List<Test> unwrittenTests = multipleChoice.Tests.ToListAsync().Result;
            foreach (Test test in writtenTests)
            {
                if (unwrittenTests.Contains(test))
                {
                    unwrittenTests.Remove(test);
                }
            }
            return unwrittenTests;
        }

        #endregion
    }
}
