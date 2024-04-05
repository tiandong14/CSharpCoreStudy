using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public List<String> Users { get; set; }
    }
}
