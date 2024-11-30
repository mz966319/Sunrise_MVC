using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sunrise.DataAccess.Repository;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Utility;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin)]
    public class ApplicationUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public ApplicationUserController(IUnitOfWork unitOfWork,UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            string CurrentUserID = user?.Id;
            List<ApplicationUser> objectUsersList = _unitOfWork.ApplicationUser.GetAll().Where(u => u.userType != SD.Role_Super_Admin).Where(u=> u.Id != CurrentUserID).OrderBy(x => x.userType).ToList();
            return View(objectUsersList);
        }

        private async Task<List<IdentityUser>> GetUsersAsync()
        {
            var users = _userManager.Users;
            return await users.ToListAsync(); // Use ToListAsync for async operation
        }



        //public IActionResult GetAll()
        //{
        //    List<ApplicationUser> objectUsersList = _unitOfWork.ApplicationUser.GetAll().ToList();
        //    return Json(new { data = objectUsersList });
        //}



        public async Task<IActionResult> LockoutUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                // Lockout user until a specific date/time (e.g., 1 hour from now)
                await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddDays(1000));
                return RedirectToAction("Index", "ApplicationUser");
            }
            return NotFound("User not found.");
        }
        public async Task<IActionResult> UnlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                // Unlockout user
                await _userManager.SetLockoutEndDateAsync(user, null);
                return RedirectToAction("Index", "ApplicationUser");
            }
            return NotFound("User not found.");
        }
    }
}
