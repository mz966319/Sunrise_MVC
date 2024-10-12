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
    public class BusRepository : Repository<Bus>,IBusRepository 
    {
        private ApplicationDbContext _db;
        public BusRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(Bus bus)
        {
            _db.Busses.Update(bus);
        }
    }
}
