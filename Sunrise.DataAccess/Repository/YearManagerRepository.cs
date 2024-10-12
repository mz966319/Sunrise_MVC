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
    public class YearManagerRepository : Repository<YearManager>, IYearManagerRepository
    {
        private ApplicationDbContext _db;
        public YearManagerRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(YearManager yearManager)
        {
            _db.YearManagers.Update(yearManager);
        }
    }
}
