using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class ErrorController1 : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
