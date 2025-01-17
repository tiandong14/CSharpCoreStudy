﻿using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// 模拟数据
/// </summary>
namespace WebApplication3.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _students;
        public MockStudentRepository() {
            _students = new List<Student>();
            _students.Add(new Student(1, "zzzz1", ClassNameEnum.FristGrade, "123455@qq.com"));
            _students.Add(new Student(2, "zzz2", ClassNameEnum.SecondGrade, "567891@qq.com"));
        }

        public Student AddStudent(Student student)
        {
           student.Id= _students.Max(s => s.Id)+1;
            _students.Add(student);
            return student;
        }

        public Student DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return this._students;
        }

        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(a => a.Id == id);
        }

        public Student UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
