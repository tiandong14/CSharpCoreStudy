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
        /// <summary>
        /// 获取所有学生
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAllStudent();
        /// <summary>
        /// 添加一位学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student AddStudent(Student student);
        /// <summary>
        /// 更新学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student UpdateStudent(Student student);

      
    }
}
