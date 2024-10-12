using Sunrise.DataAccess.Data;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(Student student)
        {
            _db.Students.Update(student);
        }
    }
}
