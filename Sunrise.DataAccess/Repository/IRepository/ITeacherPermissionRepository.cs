using Sunrise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.DataAccess.Repository.IRepository
{
    public interface ITeacherPermissionRepository : IRepository<TeacherPermission>
    {
        void Update(TeacherPermission teacherPermission);
    }
}
