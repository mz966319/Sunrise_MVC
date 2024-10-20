using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sunrise.DataAccess.Repository;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApplicationUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public ApplicationUserController(IUnitOfWork unitOfWork,UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}



        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> objectUsersList = _unitOfWork.ApplicationUser.GetAll().OrderBy(x => x.userType).ToList();
            return View(objectUsersList);
        }

        private async Task<List<IdentityUser>> GetUsersAsync()
        {
            var users = _userManager.Users;
            return await users.ToListAsync(); // Use ToListAsync for async operation
            // Get all users from the UserManager
            //var users = _userManager.Users;
            //return await Task.FromResult(users.ToList());
        }



        public IActionResult GetAll()
        {
            List<ApplicationUser> objectUsersList = _unitOfWork.ApplicationUser.GetAll().ToList();
            return Json(new { data = objectUsersList });
        }


        //public IActionResult Index()
        //{
        //    List<ApplicationUser> objectUsersList = _unitOfWork.ApplicationUser.GetAll().ToList();
        //    return View(objectUsersList);
        //}

        //private List<IdentityUser> GetUsersAsync()
        //{
        //    // Get all users from the UserManager
        //    var users = _userManager.Users;
        //    return users.ToList();
        //}


        public async Task<IActionResult> LockoutUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                // Lockout user until a specific date/time (e.g., 1 hour from now)
                await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddMinutes(2));
                return RedirectToAction("Index", "ApplicationUser");
                //return Ok("User has been locked out.");
            }
            return NotFound("User not found.");
        }
        public async Task<IActionResult> UnlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                // Lockout user until a specific date/time (e.g., 1 hour from now)
                await _userManager.SetLockoutEndDateAsync(user, null);
                return RedirectToAction("Index", "ApplicationUser");
                //return Ok("User has been locked out.");
            }
            return NotFound("User not found.");
        }
    }
}
