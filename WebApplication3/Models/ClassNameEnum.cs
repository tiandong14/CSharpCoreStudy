using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public enum ClassNameEnum
    {
        [Display(Name = "未分配")]
        [Description("未分配")]
        None,
        [Display(Name = "1班")]
        [Description("1班")]
        FristGrade,
        [Display(Name = "2班")]
        [Description("2班")]
        SecondGrade,
        [Display(Name = "3班")]
        [Description("3班")]
        GradeThree

    }
}
