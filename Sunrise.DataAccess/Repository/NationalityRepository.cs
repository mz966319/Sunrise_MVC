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
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        private ApplicationDbContext _db;
        public NationalityRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(Nationality nationality)
        {
            _db.Nationalities.Update(nationality);
        }
    }
}
