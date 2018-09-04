using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_Population.Models.CourseData
{
    public class TestQuestion
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public string TestQuestionId { get; set; }

        /// <summary>
        /// Foreign key to relate to pages
        /// </summary>
        public string PageId { get; set; }

        /// <summary>
        /// Question that a student needs to answer
        /// </summary>
        public string Question { get; set; }

		/// <summary>
		/// Optional text to go with the question
		/// </summary>
		public string OptionalText { get; set; }

		/// <summary>
		/// Position in the list of questions
		/// </summary>
		public int QuestionNumber { get; set; }

        public TestQuestion()
        {
            TestQuestionId = Guid.NewGuid().ToString();
        }
    }
}