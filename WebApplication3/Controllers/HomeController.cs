using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    
    public class HomeController : Controller
    {
        private IStudentRepository _studentRepository;

        public HomeController(IStudentRepository _studentRepository) {
            this._studentRepository = _studentRepository;
        }


        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            ViewBag.Title = "zzz";
            return View(_studentRepository.GetAllStudent());
        }
        [Route("/home/Details/{id?}")]
        public IActionResult Details(int? id) {
            //    Student student = _studentRepository.GetStudentById(2);
            //传递数据方式
            //ViewData
            //ViewBag
            //强类型视图
            HomeDetailsViewModel model = new HomeDetailsViewModel(
                _studentRepository.GetStudentById(id??1),
              "学生详情"
                );
          //  ViewBag.Title = "学生详情";
           // ViewData["Title"] = "学生详情";
           //  ViewData["Student"] = student;

            //    ViewBag.Title = "学生详情";
            //    ViewBag.Student= student;

            //相对路径 ../../MyViews/Details
            //绝对路径 ~/MyViews/Details.cshtml
            return View(model);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid) {
                Student NewStudent = _studentRepository.AddStudent(student);
                return RedirectToAction("Details", new { id = NewStudent.Id });
            }

            return View();
        }
    }
    //D:\c#Study\WebApplication3\WebApplication3\MyViews\Details.cshtml
}
