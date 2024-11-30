using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;
using Sunrise.Utility;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin)]
    public class YearController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public YearController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Year> objectYearsList = _unitOfWork.Year.GetAll().OrderByDescending(y => y.AddmissionDate).ToList();
            return View(objectYearsList);
        }

        

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Year());
            }
            else
            {
                //update
                Year year = _unitOfWork.Year.Get(u => u.YearID == id);
                return View(year);

            }
        }
        [HttpPost]
        public IActionResult Upsert(Year year)
        {
            if (ModelState.IsValid)
            {
                if (year.YearID == null || year.YearID == 0)
                {
                    // **Create Year**
                    _unitOfWork.Year.Add(year);
                    _unitOfWork.Save();
                    TempData["success"] = "Year created successfully";


                    // **Redirect to Upsert with the new YearID**
                    return RedirectToAction("Upsert", new { id = year.YearID });
                }
                else
                {
                    // **Update Year**
                    _unitOfWork.Year.Update(year);
                    _unitOfWork.Save();
                    TempData["success"] = "Year updated successfully";
                    _unitOfWork.Save();

                    // **Redirect to Index**
                    return RedirectToAction("Index", "Year");
                }
            }
            else
            {
                return View();

            }
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

        public IActionResult AddSemester(int id)
        {
            YearSemester yearSemester = new YearSemester();
            yearSemester.YearID = id;
            return View(yearSemester);

        }
        [HttpPost]
        public IActionResult AddSemester(YearSemester yearSemester)
        {
            if (ModelState.IsValid)
            {
                    // **Create Semester**
                    _unitOfWork.YearSemester.Add(yearSemester);
                    _unitOfWork.Save();
                    TempData["success"] = "Semester created successfully";


                    // **Redirect to Upsert with the new YearID**
                    return RedirectToAction("Upsert", new { id = yearSemester.YearID });
            }
            else
            {
                return View();

            }
        }


    }
}
