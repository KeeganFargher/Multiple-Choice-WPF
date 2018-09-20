using MultipleChoiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceLibrary
{
    public class TestController
    {

        #region Question methods

        /// <summary>
        /// Retrieves the text for the question
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        public string GetQuestionText(int questionID, int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .Question_Text;
            }
        }

        /// <summary>
        /// Sets the text for the question
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        /// <param name="value">The value to assign to the question</param>
        public static void SetQuestionText(int questionID, int testID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .Question_Text = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets choice A
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        public string GetChoiceA(int questionID, int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .ChoiceA;
            }
        }

        /// <summary>
        /// Sets choice A to the value specified
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        /// <param name="value">The value to assign</param>
        public static void SetChoiceA(int questionID, int testID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .ChoiceA = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets choice B
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        public string GetChoiceB(int questionID, int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .ChoiceB;
            }
        }

        /// <summary>
        /// Sets choice B to the value specified
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        /// <param name="value">The value to assign</param>
        public static void SetChoiceB(int questionID, int testID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .ChoiceB = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets choice C
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        public string GetChoiceC(int questionID, int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .ChoiceC;
            }
        }

        /// <summary>
        /// Sets choice C to the value specified
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        /// <param name="value">The value to assign</param>
        public static void SetChoiceC(int questionID, int testID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .ChoiceC = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets choice D
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        public string GetChoiceD(int questionID, int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .ChoiceD;
            }
        }

        /// <summary>
        /// Sets choice D to the value specified
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        /// <param name="value">The value to assign</param>
        public static void SetChoiceD(int questionID, int testID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .ChoiceD = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the correct answer for the question
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        public int GetAnswer(int questionID, int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .Answer;
            }
        }

        /// <summary>
        /// Sets the correct answer
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        /// <param name="value">The value to assign</param>
        public static void SetAnswer(int questionID, int testID, int value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .Answer = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the amount of points a question is worth
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        public int GetPoints(int questionID, int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .Points;
            }
        }

        /// <summary>
        /// Sets how many points a question is worth
        /// </summary>
        /// <param name="questionID">The ID of the question</param>
        /// <param name="testID">The ID of the test</param>
        /// <param name="value">The value to assign</param>
        public static void SetPoints(int questionID, int testID, int value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Question_ID == questionID && x.Test_ID == testID)
                    .Points = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Adds a new question to a test
        /// </summary>
        /// <param name="question">The question to add to the test</param>
        /// <param name="testID">The ID of the test</param>
        public static void AddQuestion(Question question, int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                question.Test_ID = testID;
                multipleChoiceEntities.Questions.Add(question);
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a question
        /// </summary>
        /// <param name="question">The question to remove</param>
        public void RemoveQuestion(Question question)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Questions.Remove(question);
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a question
        /// </summary>
        /// <param name="question">The question to remove</param>
        public static void RemoveQuestion(int questionID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                Question entity = multipleChoiceEntities.Questions.FirstOrDefault(x => x.Question_ID == questionID);
                multipleChoiceEntities.Questions.Remove(entity);
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets all the questions for the specific test
        /// </summary>
        /// <param name="testID">The ID of the test</param>
        public static List<Question> GetQuestions(int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                Test test = multipleChoiceEntities.Tests
                    .FirstOrDefaultAsync(x => x.Test_ID == testID).Result;
                return test.Questions.ToList();
            }
        }

        /// <summary>
        /// Gets a question from the specific test
        /// </summary>
        /// <param name="testID">The ID of the test</param>
        /// <param name="questionID">The ID of the question</param>
        public static Question GetQuestion(int testID, int questionID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .FirstOrDefault(x => x.Test_ID == testID && x.Question_ID == questionID);
            }
        }

        #endregion

        #region Test related methods

        /// <summary>
        /// Gets the ID of the test
        /// </summary>
        /// <param name="test">The test to get the ID of</param>
        public int GetTestID(Test test)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Tests
                    .Find(test).Test_ID;
            }
        }

        /// <summary>
        /// Retrieves the test's name
        /// </summary>
        /// <param name="testID">The ID of the test</param>
        public static string GetTestName(int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Tests
                    .FirstOrDefault(x => x.Test_ID == testID)
                    .Name;
            }
        }

        /// <summary>
        /// Sets the name of the test to the value
        /// </summary>
        /// <param name="testID">The ID of the test</param>
        /// <param name="value">The value to assign to the test</param>
        public static void SetTestName(int testID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Tests
                    .FirstOrDefault(x => x.Test_ID == testID)
                    .Name = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves the total marks a test is worth
        /// </summary>
        /// <param name="testID">The ID of the test</param>
        public static int GetTotalMarks(int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                var questions = multipleChoiceEntities.Questions
                    .Where(x => x.Test_ID == testID).ToList();
                return questions.Count == 0 ? 0 : questions.Sum(x => x.Points);
            }
        }

        /// <summary>
        /// Retrieves how many questions are in the test
        /// </summary>
        /// <param name="testID">The ID of the test</param>
        public static int GetTestSize(int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Questions
                    .CountAsync(x => x.Test_ID == testID).Result;
            }
        }

        /// <summary>
        /// Retrieves all the tests in the database
        /// </summary>
        public static async Task<List<Test>> GetAllTestsAsync()
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                List<Test> tests = await multipleChoiceEntities.Tests.ToListAsync();
                return tests;
            }
        }

        /// <summary>
        /// Adds a new test
        /// </summary>
        /// <param name="test">The test to add</param>
        public static void AddTest(Test test)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Tests.Add(test);
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a test
        /// </summary>
        /// <param name="test">The test to remove</param>
        public void RemoveTest(Test test)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Tests.Remove(test);
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Returns the test with the specified ID
        /// </summary>
        /// <param name="testID">The ID of the test</param>
        public Test GetTest(int testID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Tests
                    .FirstOrDefault(x => x.Test_ID == testID);
            }
        }

        #endregion
    }
}
