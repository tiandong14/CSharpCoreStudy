using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
   public  interface IStudentRepository
    {
        //根据id获取指定学生
        Student GetStudentById(int id);
        List<Student> GetAllStudent();

        Student AddStudent(Student student);
    }
}
