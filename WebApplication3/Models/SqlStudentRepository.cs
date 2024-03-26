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
        public SqlStudentRepository(AppDbContext appDb) {
            _appDbContext = appDb;
        }

        public Student AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _appDbContext.Students;
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
