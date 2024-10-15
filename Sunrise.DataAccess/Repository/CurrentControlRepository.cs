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
    public class CurrentControlRepository : Repository<CurrentControl>, ICurrentControlRepository
    {
        private ApplicationDbContext _db;
        public CurrentControlRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(CurrentControl currentControl)
        {
            _db.currentControls.Update(currentControl);
        }
    }
}
