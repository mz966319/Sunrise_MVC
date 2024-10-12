using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult Upsert(int? id)
        {

            StudentViewModel studentViewModel = new()
            {
                CurrentUser = "moaz",

                GradeList = _unitOfWork.Grade.GetAll().Select(u => new SelectListItem
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


            if (id == null || id == 0)
            {
                //create
                return View(studentViewModel);
            }
            else
            {
                //update
                studentViewModel.Student = _unitOfWork.Student.Get(u => u.StudentID == id, includeProperties: "CurrentClass");
                studentViewModel.GradeID = studentViewModel.Student.CurrentClass.GradeID;
                studentViewModel.ClassList = _unitOfWork.GradeClass.GetList(u => u.GradeID == studentViewModel.GradeID).Select(u => new SelectListItem
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
                if (student.StudentID == null || student.StudentID == 0)
                {
                    _unitOfWork.Student.Add(student);
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
                return View();

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

    }
}
