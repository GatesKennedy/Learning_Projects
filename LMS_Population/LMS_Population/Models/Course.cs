using System;
using System.Threading.Tasks;

namespace LMS_Population.Models.CourseData
{
    public class Course
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public string CourseId { get; set; }

        /// <summary>
        /// Name of the course for displaying purposes
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Description of the course
        /// </summary>
        public string CourseDescription { get; set; }

        /// <summary>
        /// Number of days given to complete this course
        /// </summary>
        public int DaysToComplete { get; set; }

        /// <summary>
        /// Url to course image
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Keeps track of which courses are required for graduation
        /// </summary>
        public bool Core { get; set; }

        /// <summary>
        /// Display this course for the university of concordia
        /// </summary>
        public bool UniversityOfConcordia { get; set; }

		/// <summary>
		/// Display this course for the free 
		/// </summary>
		public bool FreeCourse { get; set; }

		/// <summary>
		/// This field for keep the course in building stage 
		/// </summary>
		public bool SandBox { get; set; }

		/// <summary>
		/// Display this course for the tech academy
		/// </summary>
		public bool TechAcademy { get; set; }

        /// <summary>
        /// Order the course is on the completion list.  If the value is 0, it is not a core course
        /// </summary>
        public int CoursePosition { get; set; }

        /// <summary>
        /// Base course constructor with unique identifier
        /// </summary>
        public Course() { CourseId = Guid.NewGuid().ToString(); }

        /// <summary>
        /// Course constructor setting basic course information
        /// </summary>
        /// <param name="courseName">String value for name of the course</param>
        /// <param name="isCore">Boolean stating if the course is core or not</param>
        /// <param name="coursePosition">Position to take in the core courses.  If 0, it is an extra course</param>
        public Course(string courseName, bool isCore, int coursePosition) : base()
        {
            CourseName = courseName;
            Core = isCore;
            CoursePosition = CoursePosition;
        }
    }
}