using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Models.ViewModel;
using StudentApp.Services;

namespace StudentApp.Controllers;

public class StudentController : Controller
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    [Route("/")]
    public IActionResult Index()
    {
       List<Student>? studentList = _studentService.AllStudentList();
        IndexStudentList indexStudentList = new IndexStudentList()
        {
            Students = studentList,
            ErrorStatus = false,
            ErrorMessage=""
        };

        return View(indexStudentList);
    }

    [HttpDelete]
    [Route("Student/Delete/{studentId}")]
    public JsonResult Delete(int studentId)
    {
        IndexStudentList indexStudentList;
       bool IsDeleted = _studentService.DeleteStudent(studentId);
        if (IsDeleted)
        {
            List<Student> studentList = _studentService.AllStudentList();
            indexStudentList = new IndexStudentList()
            {
                ErrorStatus = false,
                ErrorMessage="",
                Students = studentList
            };
        }
        else
        {
            indexStudentList = new IndexStudentList()
            {
                Students = null,
                ErrorMessage="Silme işlemi gerçekleşmedi.",
                ErrorStatus=true
            };
        }

        return Json(indexStudentList);
    }


    [HttpGet]
    [Route("Student/GetById/{studentId}")]
    public JsonResult GetById(int studentId)
    {
        Student student = _studentService.GetById(studentId);
        IndexStudentList indexStudentList = new IndexStudentList()
        {
            ErrorStatus = false,
            ErrorMessage = "",
            Students = null,
            Student = student
        };

        return Json(indexStudentList);
    }

    [HttpPost]
    [Route("Student/Update")]
    public JsonResult Update(Student updateStudent)
    {
        Student student = _studentService.UpdateStudent(updateStudent);
        IndexStudentList indexStudentList = new IndexStudentList()
        {
            ErrorStatus = false,
            ErrorMessage = "",
            Students = null,
            Student = student
        };

        return Json(indexStudentList);
    }

    [HttpPost]
    [Route("Student/Insert")]
    public JsonResult Insert(Student insertStudent)
    {

        Student student = _studentService.AddStudent(insertStudent);
        IndexStudentList indexStudentList = new IndexStudentList()
        {
            ErrorStatus = false,
            ErrorMessage = "",
            Students = null,
            Student = student
        };

        return Json(indexStudentList);
    }
}

