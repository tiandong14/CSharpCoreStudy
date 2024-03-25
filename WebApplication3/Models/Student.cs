using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Student(int id, string name, ClassNameEnum className, string email)
        {
            this.Name = name;
            this.Id = id;
            this.Email = email;
            this.ClassName = className;
        }
        public Student()
        {
            // Parameterless constructor
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "名字不能为空"), MaxLength(50, ErrorMessage = "名字不能超过50个字符")]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Required(ErrorMessage = "请选择班级")]
        [Display(Name = "班级")]
        public ClassNameEnum? ClassName { get; set; }
        [Required(ErrorMessage = "请输入邮箱")]
        [Display(Name = "姓名")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "请输入有效的邮箱地址")]
        public string Email { get; set; }
    }
}
