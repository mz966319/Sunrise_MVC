using Microsoft.AspNetCore.Mvc;
using SunriseWeb.Data;
using SunriseWeb.Models;

namespace SunriseWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
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
            return RedirectToAction("Index","Student");
        }
    }
}
