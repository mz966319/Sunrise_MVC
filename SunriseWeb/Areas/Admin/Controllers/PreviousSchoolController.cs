using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Utility;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin)]
    public class PreviousSchoolController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public PreviousSchoolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            List<PreviousSchool> objectPreviousSchoolsList = _unitOfWork.PreviousSchool.GetAll().ToList();
            return View(objectPreviousSchoolsList);
        }

        

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new PreviousSchool());
            }
            else
            {
                //update
                PreviousSchool? previousSchoolFromDb = _unitOfWork.PreviousSchool.Get(u => u.PreviousSchoolID == id);
                return View(previousSchoolFromDb);

            }
        }

        [HttpPost]
        public IActionResult Upsert(PreviousSchool previousSchool)
        {
 
            if (ModelState.IsValid)
            {
                if (previousSchool.PreviousSchoolID == null || previousSchool.PreviousSchoolID == 0)
                {
                    _unitOfWork.PreviousSchool.Add(previousSchool);
                }
                else
                {
                    _unitOfWork.PreviousSchool.Update(previousSchool);
                }
                _unitOfWork.Save();
                TempData["success"] = "Previous School created successfully";

                return RedirectToAction("Index", "PreviousSchool");

            }
            else
                return View();

        }
    }
}
