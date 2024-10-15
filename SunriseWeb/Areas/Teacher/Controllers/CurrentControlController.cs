using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;

namespace SunriseWeb.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class CurrentControlController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CurrentControlController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int? id)
        {
            CurrentControlViewModel currentControlViewModel = new()
            {
                CurrentUser = "moaz",
                YearsList = _unitOfWork.Year.GetList(u => u.ActiveFlag).Select(u => new SelectListItem
                {
                    Text = "G:" + u.YearEN + " , H:" + u.YearAR,
                    Value = u.YearID.ToString()

                }),
                GradesList = _unitOfWork.Grade.GetAll().Select(u => new SelectListItem
                {
                    Text = u.GradeName,
                    Value = u.GradeID.ToString()

                })

                //Student = new Student()

            };


            if (id == null || id == 0)
            {
                //create
                return View(currentControlViewModel);
            }
            else
            {
                //update
                //studentViewModel.Student = _unitOfWork.Student.Get(u => u.StudentID == id, includeProperties: "CurrentClass");
                //studentViewModel.GradeID = studentViewModel.Student.CurrentClass.GradeID;
                //studentViewModel.ClassList = _unitOfWork.GradeClass.GetList(u => u.GradeID == studentViewModel.GradeID).Select(u => new SelectListItem
                //{
                //    Text = u.ClassName.ToString(),
                //    Value = u.GradeClassID.ToString()

                //});
                return View(currentControlViewModel);
            }





            List<CurrentControl> objectCurrentControlList = _unitOfWork.CurrentControl.GetAll().ToList();
            return View(objectCurrentControlList);
        }

        




        // GET: Admin/Year/YearSemesterUpsertPartial?yearId=5
        public IActionResult YearSemesterUpsertPartial(int yearId)
        {
            var yearSemesterList = _unitOfWork.YearSemester.GetList(
                u => u.YearID == yearId,
                includeProperties: "Year"
            ).ToList();
            if(yearSemesterList==null || yearSemesterList.Count == 0)
            {
                yearSemesterList.Add(new YearSemester());
                yearSemesterList[0].YearID = yearId;
            }
            return PartialView("_YearSemesterUpsert", yearSemesterList);
        }

        [HttpPost]
        public IActionResult UpdateSemesters(List<YearSemester> semesters)
        {

            if (ModelState.IsValid)
            {
                
                    _unitOfWork.YearSemester.UpdateRange(semesters);
                
                _unitOfWork.Save();
                TempData["success"] = "semesters updated successfully";

                //return RedirectToAction("Index", "Year");
                return RedirectToAction("Upsert", new { id = semesters[0].YearID });

            }
            else
                return RedirectToAction("Upsert", new { id = semesters[0].YearID });

        }


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
        public JsonResult GetSemesterByYearID(int yearId)
        {
            List<YearSemester> objectSemesterList = _unitOfWork.YearSemester.GetList(u => u.YearID == yearId && u.ActiveFlag ).ToList();

            //var classes = _unitOfWork.GradeClass
            //    .GetList(gc => gc.GradeID == gradeId)
            //    .Select(gc => new
            //    {
            //        ClassID = gc.GradeClassID,
            //        ClassName = gc.ClassName
            //    })
            //    .ToList();

            return Json(objectSemesterList);
        }

    }
}
