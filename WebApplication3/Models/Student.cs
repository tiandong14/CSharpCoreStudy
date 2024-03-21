using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    /// <summary>
    /// 学生模型
    /// </summary>
    public class Student
    {
        // 构造函数
        public Student(int id,string name ,string className,string email)
        {
            this.Name = name;
            this.Id = id;
            this.Email = email;
            this.ClassName = className;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string Email { get; set; }
    }
}
