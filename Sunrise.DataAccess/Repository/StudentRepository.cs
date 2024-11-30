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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db): base(db) { 
            _db = db;
        }
  

        public void Update(Student student)
        {
            _db.Students.Update(student);
        }
        public void AddStudent(Student student) {
            student.StudentID= Guid.NewGuid().ToString();
            _db.Students.Add(student);
            int? yearID = _db.Years.OrderByDescending(y => y.AddmissionDate).FirstOrDefault().YearID;
            List<YearSemester> semesters = _db.YearSemesters.Where(u=>u.YearID == yearID).ToList();
            List<Subject> subjects;
            GradeClass classItem = _db.GradeClasses.Where(u => u.GradeClassID == student.CurrentClassID).FirstOrDefault();
            if (classItem.GradeID > 3)
            {
                subjects = _db.Subjects.Where(u => !u.StaticFlag).ToList();
            }
            else
            {
                subjects = _db.Subjects.Where(u => u.SubjectID == 1 || u.SubjectID == 2 || u.SubjectID == 4
                    || u.SubjectID == 6 || u.SubjectID == 11).ToList();
            }
            foreach (YearSemester semester in semesters)
            {
                foreach (Subject subject in subjects)
                {
                    CurrentControl currentControl = new CurrentControl()
                    {

                        YearSemesterID = semester.YearSemesterID,
                        ClassID = student.CurrentClassID,
                        SubjectID = subject.SubjectID,
                        StudentID=student.StudentID
                    };
                    _db.CurrentControls.Add(currentControl);
                    _db.SaveChanges();

                }
            }

        }
    }
}
