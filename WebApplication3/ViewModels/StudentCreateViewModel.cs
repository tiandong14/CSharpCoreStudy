using Microsoft.AspNetCore.Http;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class StudentCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "名字不能为空"), MaxLength(50, ErrorMessage = "名字不能超过50个字符")]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Required(ErrorMessage = "请选择班级")]
        [Display(Name = "班级")]
        public ClassNameEnum? ClassName { get; set; }
        [Required(ErrorMessage = "请输入邮箱")]
        [Display(Name = "邮箱")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "请输入有效的邮箱地址")]
        public string Email { get; set; }
        [Display(Name="头像")]
        public IFormFile PhotoPat { get; set; }

    }
}
