using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    //自定义user类
    public class ApplicationUser:IdentityUser
    {
        public string city { get; set; }
    }
}
