using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_Population.Models.CourseData
{
    public class QuestionChoice
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public string QuestionChoiceId { get; set; }

        /// <summary>
        /// Foreign Key relating to the specific test question
        /// </summary>
        public string TestQuestionId { get; set; }

        /// <summary>
        /// Foreign Key relating to the specific Boolean question
        /// </summary>
        public string BooleanQuestionId { get; set; }

        /// <summary>
        /// Content of a choice for this questino
        /// </summary>
        public string Choice { get; set; }

        /// <summary>
        /// Declares if this is the correct choice or not
        /// </summary>
        public bool CorrectChoice { get; set; }

        public QuestionChoice()
        {
            QuestionChoiceId = Guid.NewGuid().ToString();
        }
    }
}