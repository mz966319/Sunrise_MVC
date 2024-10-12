using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeClassController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public GradeClassController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public IActionResult Index()
        {
            List<GradeClass> objectGradeClasssList = _unitOfWork.GradeClass.GetAll(includeProperties:"Grade").ToList();
            return View(objectGradeClasssList);
        }

        public IActionResult Upsert(int? id)
        {

            GradeClassViewModel gradeClassViewModel = new()
            {
                GradeList = _unitOfWork.Grade.GetAll().Select(u => new SelectListItem
                {
                    Text = u.GradeName,
                    Value = u.GradeID.ToString()

                }),
                GradeClass = new GradeClass()

            };


            if (id == null || id == 0)
            {
                //create
                return View(gradeClassViewModel);
            }
            else
            {
                //update
                gradeClassViewModel.GradeClass = _unitOfWork.GradeClass.Get(u => u.GradeClassID == id);
                return View(gradeClassViewModel);
            }
        }

        [HttpPost]
        public IActionResult Upsert(GradeClass gradeClass)
        {
 
            if (ModelState.IsValid)
            {
                string actionName = string.Empty; 
                if (gradeClass.GradeClassID == null || gradeClass.GradeClassID == 0)
                {
                    actionName = "created";
                    _unitOfWork.GradeClass.Add(gradeClass);
                }
                else
                {
                    actionName = "updated";
                    _unitOfWork.GradeClass.Update(gradeClass);
                }
                _unitOfWork.Save();
                TempData["success"] = "Class "+actionName+" successfully";

                return RedirectToAction("Index", "GradeClass");

            }
            else
                return View();

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GradeClass> objectGradeClasssList = _unitOfWork.GradeClass.GetAll(includeProperties: "Grade").ToList();
            return Json(new {data=objectGradeClasssList});
        }

        #endregion

    }
}
