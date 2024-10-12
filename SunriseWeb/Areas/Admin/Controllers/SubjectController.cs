using Microsoft.AspNetCore.Mvc;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public IActionResult Index()
        {
            List<Subject> objectSubjectsList = _unitOfWork.Subject.GetAll().ToList();
            return View(objectSubjectsList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Subject());
            }
            else
            {
                //update
                Subject? subjectFromDb = _unitOfWork.Subject.Get(u => u.SubjectID == id);
                return View(subjectFromDb);

            }
        }

        [HttpPost]
        public IActionResult Upsert(Subject subject)
        {
 
            if (ModelState.IsValid)
            {
                if (subject.SubjectID == null || subject.SubjectID == 0)
                {
                    _unitOfWork.Subject.Add(subject);
                }
                else
                {
                    _unitOfWork.Subject.Update(subject);
                }
                _unitOfWork.Save();
                TempData["success"] = "Subject created successfully";

                return RedirectToAction("Index", "Subject");

            }
            else
                return View();

        }
    }
}
