using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sunrise.DataAccess.Data;
using Sunrise.DataAccess.Repository.IRepository;

namespace Sunrise.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet=_db.Set<T>();
            //_db.GradeClasses.Include(u => u.Grade).Include(u => u.Grade).Include(u => u.Grade);
            _db.GradeClasses.Include(u => u.Grade).Include(u=>u.GradeID);
            _db.Students
                .Include(u=>u.CurrentClass).Include(u=>u.CurrentClassID)
                .Include(u=>u.CountryBirth).Include(u=>u.BirthPlaceID)
                .Include(u=>u.PreviousSchool).Include(u => u.PreviousSchoolID)
                .Include(u => u.Bus).Include(u => u.BusID)
                .Include(u => u.Nationality).Include(u => u.NationalityID);

            _db.YearManagers.Include(u => u.Grade).Include(u => u.GradeID)
                .Include(u => u.Year).Include(u => u.YearID);
            _db.YearManagers.Include(u => u.Year).Include(u => u.YearID);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includePrp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePrp);
                }
            }
            
            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includePrp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePrp);
                }
            }

            return query.ToList(); 
        }


        //Grade,Model or any model obj as a forign key
        public IEnumerable<T> GetAll(string?includeProperties =null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includePrp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(includePrp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            dbSet.UpdateRange(entities);
        }
    }
}
