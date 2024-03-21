using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
namespace WebApplication3.ViewModels
{
    public class HomeDetailsViewModel
    {
        public HomeDetailsViewModel(Student student, string title) {
            this.Student = student;
            this.Title = title;
        }

      public Student Student { get; set; }
        public string Title { get; set; }
    }
}
