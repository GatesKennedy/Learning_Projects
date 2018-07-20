using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS_Population.Models.CourseData
{
    public class PageField
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public string PageFieldId { get; set; }

        /// <summary>
        /// Foreign Key relating to this fields page
        /// </summary>
        public string PageId { get; set; }

        /// <summary>
        /// Foreign Key relating to this boolean page question
        /// </summary>
        public string BooleanQuestionId { get; set; }

        /// <summary>
        /// Dictates what kind of html element this will be
        /// </summary>
        [Required]
        public string FieldType { get; set; }

        /// <summary>
        /// Content of the field.  Could be a link or a video.
        /// </summary>
        public string Content { get; set; }

		/// <summary>
		/// if this drill is final essay
		/// </summary>
		public bool FinalEssay { get; set; }

		/// <summary>
		/// Current position in comparison to other fields for ordering
		/// </summary>
		[Required]
        public int FieldNumber { get; set; }

        [Required]
        public string FieldTitle { get; set; }

        [Required]
        public string FieldReference { get; set; }

        public PageField()
        {
            PageFieldId = Guid.NewGuid().ToString();
        }
    }
}