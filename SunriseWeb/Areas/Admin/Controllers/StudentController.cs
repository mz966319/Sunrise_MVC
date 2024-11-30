using Microsoft.AspNetCore.Authorization;
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
    public class StudentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public IActionResult Index()
        {
            List<Student> objectStudentList = _unitOfWork.Student.GetAll(includeProperties: "Nationality,PreviousSchool,CurrentClass,CountryBirth,Bus").ToList();
            
            return View(objectStudentList);
        }

        public IActionResult Upsert(string? id)
        {

            StudentViewModel studentViewModel = new()
            {
                CurrentUser = "moaz",

                CurrentGradeList = _unitOfWork.Grade.GetAll().Select(u => new SelectListItem
                {
                    Text = u.GradeName,
                    Value = u.GradeID.ToString()

                }),
                TmpGradeList = _unitOfWork.Grade.GetAll().Select(u => new SelectListItem
                {
                    Text = u.GradeName,
                    Value = u.GradeID.ToString()

                }),
                NationalityList = _unitOfWork.Nationality.GetAll().Select(u => new SelectListItem
                {
                    Text = u.NationalityEN,
                    Value = u.NationalityID.ToString()

                }),
                CountryList = _unitOfWork.Country.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CountryNameEN,
                    Value = u.CountryID.ToString()

                }),
                PreviousSchoolList = _unitOfWork.PreviousSchool.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PreviousSchoolNameEN,
                    Value = u.PreviousSchoolID.ToString()

                }),
                BusList = _unitOfWork.Bus.GetAll().Select(u => new SelectListItem
                {
                    Text = u.BusNumber.ToString(),
                    Value = u.BusID.ToString()

                }),

                Student = new Student()

            };


            if (id == null)
            {
                //create
                return View(studentViewModel);
            }
            else
            {
                //update
                studentViewModel.Student = _unitOfWork.Student.Get(u => u.StudentID == id, includeProperties: "CurrentClass,TemporaryClass");
                studentViewModel.CurrentGradeID = studentViewModel.Student.CurrentClass.GradeID;
                studentViewModel.CurrentClassList = _unitOfWork.GradeClass.GetList(u => u.GradeID == studentViewModel.CurrentGradeID).Select(u => new SelectListItem
                {
                    Text = u.ClassName.ToString(),
                    Value = u.GradeClassID.ToString()

                });
                studentViewModel.TmpGradeID = studentViewModel.Student.TemporaryClass?.GradeID??0;
                studentViewModel.TmpClassList = _unitOfWork.GradeClass.GetList(u => u.GradeID == studentViewModel.TmpGradeID).Select(u => new SelectListItem
                {
                    Text = u.ClassName.ToString(),
                    Value = u.GradeClassID.ToString()

                });

                return View(studentViewModel);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Student student)
        {
 
            if (ModelState.IsValid)
            {
                if (student.StudentID == null)
                {
                    _unitOfWork.Student.AddStudent(student);
                }
                else
                {
                    _unitOfWork.Student.Update(student);
                }
                _unitOfWork.Save();
                TempData["success"] = "Student created successfully";

                return RedirectToAction("Index", "Student");

            }
            else
                return View(student);

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> objectStudentList = _unitOfWork.Student.GetAll(includeProperties: "Nationality,PreviousSchool,CurrentClass,CurrentClass.Grade,CountryBirth,Bus").ToList();
            return Json(new {data= objectStudentList});
        }

        #endregion
        //public IActionResult GetClassByGradeID(int gradeId)
        //{
        //    var objectGradeClassList = _unitOfWork.GradeClass.GetList(u => u.GradeID == gradeId).ToList();

        //    var classes = _unitOfWork.GradeClass
        //        .GetList(gc => gc.GradeID == gradeId)
        //        .Select(gc => new
        //        {
        //            ClassID = gc.GradeClassID,
        //            ClassName = gc.ClassName
        //        })
        //        .ToList();

        //    return Ok(classes);
        //}
        public JsonResult GetClassByGradeID(int gradeId)
        {
            List<GradeClass> objectGradeClassList = _unitOfWork.GradeClass.GetList(u => u.GradeID == gradeId).ToList();

            var classes = _unitOfWork.GradeClass
                .GetList(gc => gc.GradeID == gradeId)
                .Select(gc => new
                {
                    ClassID = gc.GradeClassID,
                    ClassName = gc.ClassName
                })
                .ToList();

            return Json(objectGradeClassList);
        }
        public IActionResult CreatePDF()
        {
            List<Student> students = _unitOfWork.Student.GetList(u => u.StudentActiveFlag == SD.Student_Status_Active, includeProperties: "Bus,CurrentClass,CurrentClass.Grade").OrderBy(u =>u.StudentNameEN).ToList();
            var pdfBytes = new StudentsPDF(students).GeneratePdf();
            Response.Headers.Add("Content-Disposition", "inline; filename=Students.pdf");
            return File(pdfBytes, "application/pdf");
        }

    }
}
