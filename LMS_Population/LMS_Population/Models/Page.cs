using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_Population.Models.CourseData
{
    public class Page
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public string PageId { get; set; }

        /// <summary>
        /// Foreign key relating to the course this page belongs to
        /// </summary>
        public string CourseId { get; set; }

        /// <summary>
        /// Nullable page number.  If the number is null, it is considered an inactive page.
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Dictates whether this page is a test or not.
        /// </summary>
        public bool IsTest { get; set; }

        public Page()
        {
            PageId = Guid.NewGuid().ToString();
        }
    }
}