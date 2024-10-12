using Microsoft.AspNetCore.Mvc;
using Sunrise.DataAccess.Data;
using Sunrise.Models;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController2 : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController2(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Student> objectStudentList = _db.Students.ToList();
            return View(objectStudentList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}
