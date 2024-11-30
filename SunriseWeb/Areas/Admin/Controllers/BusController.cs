using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Utility;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin)]
    public class BusController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public BusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public IActionResult Index()
        {
            List<Bus> objectBussList = _unitOfWork.Bus.GetAll().ToList();
            return View(objectBussList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Bus());
            }
            else
            {
                //update
                Bus? busFromDb = _unitOfWork.Bus.Get(u => u.BusID == id);
                return View(busFromDb);

            }
        }

        [HttpPost]
        public IActionResult Upsert(Bus bus)
        {
 
            if (ModelState.IsValid)
            {
                if (bus.BusID == null || bus.BusID == 0)
                {
                    _unitOfWork.Bus.Add(bus);
                }
                else
                {
                    _unitOfWork.Bus.Update(bus);
                }
                _unitOfWork.Save();
                TempData["success"] = "Bus created successfully";

                return RedirectToAction("Index", "Bus");

            }
            else
                return View();

        }
    }
}
