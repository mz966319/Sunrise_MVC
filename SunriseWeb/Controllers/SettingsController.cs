using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SunriseWeb.Data;
using SunriseWeb.Models;
using System.Linq;

namespace SunriseWeb.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SettingsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Countries()
        {
            List<Country> objectCountryList = _db.Countries.ToList();
            return View(objectCountryList);
        }

        public IActionResult CreateCountry()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateCountry(Country country)
        {
            if (country.NationalityARFemale.ToString() == country.NationalityARMale.ToString())
            {
                ModelState.AddModelError("NationalityARFemale", "الجنسية بالعربي للبنين يجب ان تختلف عن الجنسية بالعربي للبنات");
            }
            if (ModelState.IsValid)
            {
                _db.Countries.Add(country);
                _db.SaveChanges();
                TempData["success"] = "Country created successfully";

                return RedirectToAction("Countries", "Settings");

            }
            return View();
        }



        public IActionResult EditCountry(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Country? contryFromDb = _db.Countries.Find(id);
            Country? contryFromDb = _db.Countries.FirstOrDefault(u => u.CountryID == id);
            //Country? contryFromDb3 = _db.Countries.Where(u => u.CountryID == id).FirstOrDefault();


            return View(contryFromDb);
        }

        [HttpPost]
        public IActionResult EditCountry(Country country)
        {
            //if (country.NationalityARFemale.ToString() == country.NationalityARMale.ToString())
            //{
            //    ModelState.AddModelError("NationalityARFemale", "الجنسية بالعربي للبنين يجب ان تختلف عن الجنسية بالعربي للبنات");
            //}
            if (ModelState.IsValid)
            {
                _db.Countries.Update(country);
                _db.SaveChanges();
                TempData["success"] = "Country edited successfully";
                return RedirectToAction("Countries", "Settings");

            }
            return View();
        }
    }
}
