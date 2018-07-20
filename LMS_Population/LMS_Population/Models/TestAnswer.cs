using System;

namespace LMS_Population.Models.UserData
{
    public class TestAnswer
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public string TestAnswerId { get; set; }

        /// <summary>
        /// Foreign Key relating to the results for a student's test result
        /// </summary>
        public string StudentTestResultId { get; set; }

        /// <summary>
        /// Foreign Key relating to a specific test question
        /// </summary>
        public string TestQuestionId { get; set; }

        /// <summary>
        /// Selected answer at time of the test
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Tracks if the response was correct or not
        /// </summary>
        public bool Correct { get; set; }

        // TODO Use AnsweredOnTest property when implementing Knowledge checks to
        // track whether the student answered the question as part of a test
        // or as part of a knowledge check
        /// <summary>
        /// Tracks whether the question was answered as part of a test.
        /// </summary>
        public bool AnsweredOnTest { get; set; }

        public TestAnswer()
        {
            TestAnswerId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Sets Response,Correct, and TestQuestionId using TestAnswersViewModel
        /// </summary>
        //public TestAnswer(TestAnswersViewModel vm)
        //{
        //    TestAnswerId = Guid.NewGuid().ToString();
        //    Response = vm.Answer;
        //    Correct = vm.Correct;
        //    TestQuestionId = vm.TestQuestionId;
        //    AnsweredOnTest = false;
        //}
    }
}