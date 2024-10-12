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
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private ApplicationDbContext _db;
        public SubjectRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(Subject subject)
        {
            _db.Subjects.Update(subject);
        }
    }
}
