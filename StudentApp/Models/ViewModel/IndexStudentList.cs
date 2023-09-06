using System;
namespace StudentApp.Models.ViewModel
{
	public class IndexStudentList
	{
		public List<Student>? Students { get; set; }
		public bool ErrorStatus { get; set; }
		public string? ErrorMessage { get; set; }
		public Student Student { get; set; }
	}
}

