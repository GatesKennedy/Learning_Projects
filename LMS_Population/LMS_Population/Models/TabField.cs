using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS_Population.Models.CourseData
{
	public class TabField
	{
		/// <summary>
		/// Primary Key
		/// </summary>
		[Key]
		public string TabFieldId { get; set; }

		/// <summary>
		/// Foreign Key relating to this fields page
		/// </summary>
		public string PageId { get; set; }

		/// <summary>
		/// Foreign Key relating to the page field
		/// </summary>
		public string PageFieldId { get; set; }

		/// <summary>
		/// Tab number field
		/// </summary>
		[Required]
		public int TabNumber { get; set; }

		/// <summary>
		/// Current position in comparison to other fields for ordering
		/// </summary>
		[Required]
		public string TabName { get; set; }

		/// <summary>
		/// Heading of the tab content
		/// </summary>
		public string Heading { get; set; }

		/// <summary>
		/// Content of the field.  Could be a link or a video.
		/// </summary>
		public string Content { get; set; }

		


		public TabField()
		{
			TabFieldId = Guid.NewGuid().ToString();
		}
	}
}