using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{

    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly HostingEnvironment _webHostEnvironment;
        public HomeController(IStudentRepository _studentRepository, HostingEnvironment hostingEnvironment)
        {
            this._studentRepository = _studentRepository;
            this._webHostEnvironment = hostingEnvironment;
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
        public IActionResult Details(int? id)
        {
            //    Student student = _studentRepository.GetStudentById(2);
            //传递数据方式
            //ViewData
            //ViewBag
            //强类型视图
            HomeDetailsViewModel model = new HomeDetailsViewModel(
                _studentRepository.GetStudentById(id ?? 1),
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
        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    //必须将图片文件上传到wwwroot的images文件夹中
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    //为了确保文件名是唯一的，我们在文件名后附加一个新的GUID值和一个下划线
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Student newStudent = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    ClassName = model.ClassName,
                    // 将文件名保存在Student对象的PhotoPath属性中
                    //它将被保存到数据库Students的表中
                    PhotoPat = uniqueFileName
                };
                _studentRepository.AddStudent(newStudent);

                return RedirectToAction("Details", new { id = newStudent.Id });
            }

            return View();
        }
    }
    //D:\c#Study\WebApplication3\WebApplication3\MyViews\Details.cshtml
}
