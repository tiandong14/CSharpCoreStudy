
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;
namespace StudentManagement.Models
{
    public class ModelBuilderExtensions
    {
        public static void Seed( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student(id: 1, name: "zzz", className: ClassNameEnum.FristGrade,
                email: "1234567@qq.com"));
        }
    }
}
