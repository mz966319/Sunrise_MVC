using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICountryRepository Country { get; }
        IStudentRepository Student { get; }
        IBusRepository Bus { get; }
        IGradeClassRepository GradeClass { get; }
        IGradeRepository Grade {  get; }
        IPreviousSchoolRepository PreviousSchool { get; }
        ISubjectRepository Subject { get; }
        INationalityRepository Nationality { get; }
        IYearRepository Year { get; }
        IYearManagerRepository YearManager { get; }
        IYearSemesterRepository YearSemester { get; }

        void Save();
    }
}
