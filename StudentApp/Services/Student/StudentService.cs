using StudentApp.Models;
using StudentApp.Repository;

namespace StudentApp.Services
{
	public class StudentService
	{
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
		{
            _studentRepository = studentRepository;
        }


        public Student AddStudent(Student student)
        {
            return _studentRepository.AddStudent(student);
        }

        public List<Student> AllStudentList()
        {
            return _studentRepository.AllStudentList();
        }

        public bool DeleteStudent(int id)
        {
           return _studentRepository.DeleteStudent(id);
        }

        public Student UpdateStudent(Student student)
        {
            return _studentRepository.UpdateStudent(student);
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

    }
}

