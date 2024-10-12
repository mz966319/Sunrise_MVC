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
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        private ApplicationDbContext _db;
        public GradeRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(Grade grade)
        {
            _db.Grades.Update(grade);
        }
    }
}
