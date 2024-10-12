using Sunrise.DataAccess.Data;
using Sunrise.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICountryRepository Country{ get; private set; }
        public IBusRepository Bus { get; private set; }
        public IGradeClassRepository GradeClass { get; private set; }
        public IGradeRepository Grade { get; private set; }
        public IPreviousSchoolRepository PreviousSchool { get; private set; }
        public IStudentRepository Student { get; private set; }
        public ISubjectRepository Subject { get; private set; }
        public INationalityRepository Nationality { get; private set; }
        public IYearRepository Year { get; private set; }
        public IYearManagerRepository YearManager { get; private set; }
        public IYearSemesterRepository YearSemester { get; private set; }



        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Country = new CountryRepository(_db);
            Bus = new BusRepository(_db);
            GradeClass = new GradeClassRepository(_db);
            Grade = new GradeRepository(_db);
            PreviousSchool = new PreviousSchoolRepository(_db);
            Student = new StudentRepository(_db);
            Subject = new SubjectRepository(_db);
            Nationality = new NationalityRepository(_db);
            Year = new YearRepository(_db);
            YearManager = new YearManagerRepository(_db);
            YearSemester = new YearSemesterRepository(_db);


        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
