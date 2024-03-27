using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace StudentManagement.Models
{
    public class SqlStudentRepository : IStudentRepository
    {
        AppDbContext _appDbContext;
        public SqlStudentRepository(AppDbContext appDb)
        {
            _appDbContext = appDb;
        }

        public Student AddStudent(Student student)
        {
            _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
            return student;
        }

        public Student DeleteStudent(int id)
        {
            Student student = _appDbContext.Students.Find(id);
            if (student != null)
            {
                _appDbContext.Students.Remove(student);
                _appDbContext.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {

            return _appDbContext.Students;
        }

        public Student GetStudentById(int id)
        {
            return _appDbContext.Students.Find(id);
        }

        public Student UpdateStudent(Student student)
        {
            var add_student = _appDbContext.Students.Attach(student);
            add_student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.Update(add_student);
            _appDbContext.SaveChanges();
            return student;
        }
    }
}
