
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;
namespace StudentManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student(id: 1, name: "zzz", className: ClassNameEnum.FristGrade,
                email: "1234567@qq.com"));
        }
    }
}
