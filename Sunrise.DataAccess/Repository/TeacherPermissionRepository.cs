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
    public class TeacherPermissionRepository : Repository<TeacherPermission>, ITeacherPermissionRepository
    {
        private ApplicationDbContext _db;
        public TeacherPermissionRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(TeacherPermission teacherPermission)
        {
            _db.TeacherPermissions.Update(teacherPermission);
        }
    }
}
