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
    public class YearSemesterRepository : Repository<YearSemester>, IYearSemesterRepository
    {
        private ApplicationDbContext _db;
        public YearSemesterRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(YearSemester yearSemester)
        {
            _db.YearSemesters.Update(yearSemester);
        }
    }
}
