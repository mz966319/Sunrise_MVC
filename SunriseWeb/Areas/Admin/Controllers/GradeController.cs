using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Utility;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin)]
    [Authorize(Roles =SD.Role_Admin+","+ SD.Role_Super_Admin)]

    public class GradeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public GradeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            List<Grade> objectGradeList = _unitOfWork.Grade.GetAll().ToList();
            return View(objectGradeList);
        }

        

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Grade());
            }
            else
            {
                //update
                Grade? gradeFromDb = _unitOfWork.Grade.Get(u => u.GradeID == id);
                return View(gradeFromDb);

            }
        }

        [HttpPost]
        public IActionResult Upsert(Grade grade)
        {
 
            if (ModelState.IsValid)
            {
                if (grade.GradeID == null || grade.GradeID == 0)
                {
                    _unitOfWork.Grade.Add(grade);
                }
                else
                {
                    _unitOfWork.Grade.Update(grade);
                }
                _unitOfWork.Save();
                TempData["success"] = "Grade created successfully";

                return RedirectToAction("Index", "Grade");

            }
            else
                return View();

        }
    }
}
