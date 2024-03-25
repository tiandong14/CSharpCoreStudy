using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public enum ClassNameEnum
    {
        [Display(Name = "未分配")]
        None,
        [Display(Name = "1班")]
        FristGrade,
        [Display(Name = "2班")]
        SecondGrade,
        [Display(Name = "3班")]
        GradeThree

    }
}
