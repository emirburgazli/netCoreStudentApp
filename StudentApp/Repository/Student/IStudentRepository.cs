using System;
using StudentApp.Models;

namespace StudentApp.Repository
{
	public interface IStudentRepository
	{
        List<Student> AllStudentList();
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        Student GetById(int id);
        bool DeleteStudent(int id);
    }
}

