using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;
using Sunrise.Utility;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin)]
    public class ControlReportsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ControlReportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Semester()
        {

            var grades = GetGrades();
            ControlReportsViewModel controlReportsViewModel = new()
            {
                YearsList = _unitOfWork.Year.GetList(u => u.ActiveFlag).OrderByDescending(y => y.AddmissionDate).Select(u => new SelectListItem
                {
                    Text = "G:" + u.YearEN + " , H:" + u.YearAR,
                    Value = u.YearID.ToString()

                }),
                GradesList = grades.Select(u => new SelectListItem { Text = u.GradeName, Value = u.GradeID.ToString() })
            };
            return View(controlReportsViewModel);
        }
        [HttpPost]
        public IActionResult GenerateSemesterReports(ControlReportsViewModel VM)
        {
            if (ModelState.IsValid)
            {
                List<Student> students = _unitOfWork.Student.GetList(u => u.StudentActiveFlag == SD.Student_Status_Active, includeProperties: "Bus,CurrentClass,CurrentClass.Grade").OrderBy(u => u.StudentNameEN).ToList();
                List<CurrentControl> currentControls = _unitOfWork.CurrentControl.GetList(u => u.YearSemesterID == VM.SemesterID, includeProperties: "YearSemester,Subject,YearSemester.Year").ToList();
                var pdfBytes = new SemesterReportPDF(students, currentControls,_unitOfWork).GeneratePdf();
                Response.Headers.Add("Content-Disposition", "inline; filename=SemesterReport.pdf");
                return File(pdfBytes, "application/pdf");
                //return Json(VM);
            }
            return File("", "application/pdf");
        }

        public List<Grade> GetGrades()
        {
            List<Grade> grades = _unitOfWork.Grade.GetAll().ToList();
            return grades;
        }
 
        public List<GradeClass> GetClasses(int gradeId)
        {
            List<GradeClass> classes = _unitOfWork.GradeClass.GetList(u => u.GradeID == gradeId).ToList();
            return classes;
        }
        public List<Student> GetStudents(int yearId,int semesterId,int classId)
        {
            List<Student> students = new();
            List<CurrentControl> currentControls = _unitOfWork.CurrentControl.GetList( u => u.YearSemesterID==yearId && u.YearSemesterID==semesterId  && u.ClassID == classId,includeProperties:"Student").ToList();
            foreach (CurrentControl currentControl in currentControls)
            {
                if(!students.Contains(currentControl.Student))
                    students.Add(currentControl.Student);
            }

            return students;
        }



        public JsonResult GetSemesterByYearID(int yearId)
        {
            List<YearSemester> semesterList = _unitOfWork.YearSemester.GetList(u => u.YearID == yearId && u.ActiveFlag ).ToList();
            return Json(semesterList);
        }

        public JsonResult GetClassByGradeID(int gradeId)
        {
            
            return Json(GetClasses(gradeId));
        }
        public JsonResult GetStudentsByYearIDSemesterIDClassID(int yearId, int semesterId, int classId)
        {

            return Json(GetStudents(yearId, semesterId, classId));
        }

    }
}
