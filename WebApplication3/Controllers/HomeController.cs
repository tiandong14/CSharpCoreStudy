using Microsoft.AspNetCore.Hosting;

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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IStudentRepository _studentRepository, IWebHostEnvironment hostingEnvironment)
        {
            this._studentRepository = _studentRepository;
            this._webHostEnvironment = hostingEnvironment;
        }
        private string ProcessUploadedFile(StudentCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                //必须将图片文件上传到wwwroot的images/avatars文件夹中
                //而要获取wwwroot文件夹的路径，我们需要注入ASP.NET Core提供的
                //webHostEnvironment服务
                //通过webHostEnvironment服务去获取wwwroot文件夹的路径
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatars");
                //为了确保文件名是唯一的，我们在文件名后附加一个新的GUID值和一
                //个下划线
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // 使用 using 语句
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    //开始复制
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student_find = _studentRepository.GetStudentById(id);
            if (student_find == null)
            {
                return View("StudentNotFound", id);
            }
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel
            {
                Id = student_find.Id,
                Name = student_find.Name,
                Email = student_find.Email,
                ClassName = student_find.ClassName,
                ExistingPhotoPath = student_find.PhotoPat
            };
            return View(studentEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel model)
        {
            if (ModelState.IsValid && !model.Id.Equals(null))
            {
                Student student = _studentRepository.GetStudentById(model.Id);
                student.Name = model.Name;
                student.Email = model.Email;
                student.ClassName = model.ClassName;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatars", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    student.PhotoPat = ProcessUploadedFile(model);
                }
                _studentRepository.UpdateStudent(student);
                return RedirectToAction("index");
            }
            return View(model);
        }


        [Route("")]
        [Route("/home")]
        [Route("/home/index")]
        public IActionResult Index()
        {
            ViewBag.Title = "zzz";
            return View(_studentRepository.GetAllStudent());
        }
        [Route("/home/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            Student stu = _studentRepository.GetStudentById(id ?? 1);
            if (stu == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id);
            }
            //    Student student = _studentRepository.GetStudentById(2);
            //传递数据方式
            //ViewData
            //ViewBag
            //强类型视图
            HomeDetailsViewModel model = new HomeDetailsViewModel(stu
               ,
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
                    uniqueFileName = ProcessUploadedFile(model);
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


}
