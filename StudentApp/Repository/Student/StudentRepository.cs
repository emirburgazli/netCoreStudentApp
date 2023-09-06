using System;
using System.Collections.Generic;
using StudentApp.Entity;
using StudentApp.Models;

namespace StudentApp.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IRedisMemories _redis;
        private readonly AppDbContext _dbContext;
        public StudentRepository(AppDbContext dbContext, IRedisMemories redis)
        {
            _dbContext = dbContext;
            _redis = redis;
        }

        public List<Student> AllStudentList()
        {
            //redisde var ise oradan çeker yok ise db gider.
            //List<Student> RedisStudent = _redis.GetRedisData<List<Student>>(new List<Student>(), "", 50); ;
            //if (RedisStudent.Count > 0)
            //{
            //  return RedisStudent;
            //}

            List<Student>? list = _dbContext.Student.ToList();
            return list;

        }

        Student IStudentRepository.AddStudent(Student student)
        {
            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();
            return student;
        }

        Student IStudentRepository.UpdateStudent(Student student)
        {
            _dbContext.Student.Update(student);
            _dbContext.SaveChanges();
            return student;
        }

        bool IStudentRepository.DeleteStudent(int id)
        {
            try
            {
                Student? student = _dbContext.Student.Where(x => x.Id == id).FirstOrDefault();
                if (student != null)
                {
                    _dbContext.Remove(student);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }


        }

        Student IStudentRepository.GetById(int id)
        {
            return _dbContext.Student.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

