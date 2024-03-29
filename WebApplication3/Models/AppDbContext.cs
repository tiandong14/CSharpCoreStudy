using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace StudentManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Student>().HasData(
              new Student(id:1,name:"zzz",className:ClassNameEnum.FristGrade,
              email:"1234567@qq.com"));
        }
    }
}
