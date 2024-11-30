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
    public class CountryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public IActionResult Index()
        {
            CountryNationalityViewModel countryNationalityViewModel = new()
            {
                CountryList = _unitOfWork.Country.GetAll().ToList(),
                NationalityList = _unitOfWork.Nationality.GetAll().ToList()
            };

            //List<Country> objectCountryList = _unitOfWork.Country.GetAll().ToList();
            return View(countryNationalityViewModel);
        }

        public IActionResult UpsertCountry(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Country());
            }
            else
            {
                //update
                Country? countryFromDb = _unitOfWork.Country.Get(u => u.CountryID == id);
                return View(countryFromDb);

            }
        }

        [HttpPost]
        public IActionResult UpsertCountry(Country country)
        {
 
            if (ModelState.IsValid)
            {
                if (country.CountryID == null || country.CountryID == 0)
                {
                    _unitOfWork.Country.Add(country);
                }
                else
                {
                    _unitOfWork.Country.Update(country);
                }
                _unitOfWork.Save();
                TempData["success"] = "Country created successfully";

                return RedirectToAction("Index", "Country");

            }
            else
                return View();

        }

        public IActionResult UpsertNationality(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Nationality());
            }
            else
            {
                //update
                Nationality? nationalityFromDb = _unitOfWork.Nationality.Get(u => u.NationalityID == id);
                return View(nationalityFromDb);

            }
        }

        [HttpPost]
        public IActionResult UpsertNationality(Nationality nationality)
        {
            if (nationality.NationalityARFemale.ToString() == nationality.NationalityARMale.ToString())
            {
                ModelState.AddModelError("NationalityARFemale", "الجنسية بالعربي للبنين يجب ان تختلف عن الجنسية بالعربي للبنات");
            }

            if (ModelState.IsValid)
            {
                if (nationality.NationalityID == null || nationality.NationalityID == 0)
                {
                    _unitOfWork.Nationality.Add(nationality);
                }
                else
                {
                    _unitOfWork.Nationality.Update(nationality);
                }
                _unitOfWork.Save();
                TempData["success"] = "Nationality created successfully";

                return RedirectToAction("Index", "Country");

            }
            else
                return View(nationality);

        }
    }
}
