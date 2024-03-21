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
        public IActionResult Index()
        {
            ViewBag.Title = "zzz";
            return View(_studentRepository.GetAllStudent());
        }
        public IActionResult Details() {
            //    Student student = _studentRepository.GetStudentById(2);
            //传递数据方式
            //ViewData
            //ViewBag
            //强类型视图
            HomeDetailsViewModel model = new HomeDetailsViewModel(
                _studentRepository.GetStudentById(1),
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
    }
    //D:\c#Study\WebApplication3\WebApplication3\MyViews\Details.cshtml
}
