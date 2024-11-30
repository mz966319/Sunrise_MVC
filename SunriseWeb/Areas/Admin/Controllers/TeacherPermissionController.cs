using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;
using Sunrise.Utility;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin)]
    public class TeacherPermissionController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public TeacherPermissionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string id)
        {
            TempData["UserID"] = id;
            TempData["UserName"] = _unitOfWork.ApplicationUser.Get(u => u.Id == id).FullName.ToString();
            List<TeacherPermission> objectTeacherPermissionsList = _unitOfWork.TeacherPermission.GetList(u => u.UserID == id, includeProperties: "User,Subject,Class,Class.Grade").ToList();
            Dictionary<Subject, List<TeacherPermission>> subjectMap = objectTeacherPermissionsList
                .GroupBy(tp => tp.Subject).ToDictionary(g => g.Key, g => g.ToList());
            return View(subjectMap);
        }

        public IActionResult Create(string id)
        {

            TeacherPermissionViewModel permissionViewModel = new()
            {
                UserID = id,
                GradesList = _unitOfWork.Grade.GetAll().Select(u => new SelectListItem
                {
                    Text = u.GradeName,
                    Value = u.GradeID.ToString()

                }),
                SubjectsList = _unitOfWork.Subject.GetList(u => u.StaticFlag == false).OrderBy(u => u.SubjectNameEN).Select(s => new SelectListItem
                {
                    Text = s.SubjectNameEN,
                    Value = s.SubjectID.ToString()
                })
            };
            return View(permissionViewModel);

        }

        [HttpPost]
        public IActionResult Create(TeacherPermissionViewModel permissionViewModel)
        {
            TeacherPermission toCheck = _unitOfWork.TeacherPermission.Get(u => u.UserID == permissionViewModel.UserID
                && u.Class.GradeID == permissionViewModel.GradeID && u.Class.GradeClassID == permissionViewModel.ClassID
                && u.SubjectID == permissionViewModel.SubjectID);
            if (toCheck != null)
            {
                ModelState.AddModelError("ClassID", "Permissions for this grade, class and subject have been added before!");
            }
            if (ModelState.IsValid)
            {
                TeacherPermission teacherPermission = new()
                {
                    TeacherPermissionID = 0,
                    PermissionType = permissionViewModel.PermissionType,
                    UserID = permissionViewModel.UserID,
                    SubjectID = permissionViewModel.SubjectID,
                    ClassID = permissionViewModel.ClassID,
                    AcitveFlag = true
                };
                _unitOfWork.TeacherPermission.Add(teacherPermission);
                _unitOfWork.Save();
                TempData["success"] = "Teacher Permission created successfully";
                return RedirectToAction("Index", "TeacherPermission", new { id = teacherPermission.UserID });

            }
            else
            {
                permissionViewModel.GradesList = _unitOfWork.Grade.GetAll().Select(u => new SelectListItem
                {
                    Text = u.GradeName,
                    Value = u.GradeID.ToString()

                });
                permissionViewModel.ClassesList = _unitOfWork.GradeClass.GetList(u => u.GradeID == permissionViewModel.GradeID).Select(u => new SelectListItem
                {
                    Text = u.ClassName,
                    Value = u.GradeClassID.ToString()

                });
                permissionViewModel.SubjectsList = _unitOfWork.Subject.GetList(u => u.StaticFlag == false).OrderBy(u => u.SubjectNameEN).Select(s => new SelectListItem
                {
                    Text = s.SubjectNameEN,
                    Value = s.SubjectID.ToString()
                });

                return View(permissionViewModel);
            }
        }

        
        public IActionResult Delete(int? id)
        {
            TeacherPermission? teacherPermission= _unitOfWork.TeacherPermission.Get(u=>u.TeacherPermissionID==id);

            if (teacherPermission == null)
            {
                return NotFound();
            }

            _unitOfWork.TeacherPermission.Remove(teacherPermission);
            _unitOfWork.Save();

            TempData["success"] = "Teacher Permission removed successfully";
            return RedirectToAction("Index", "TeacherPermission", new { id = teacherPermission.UserID });
            //return View();

        }
        public IActionResult Not(string? idd)
        {
           

            TempData["success"] = "Teacher Permission removed successfully";
            return RedirectToAction("Index", "TeacherPermission", new { id = idd });
            //return View();

        }


    }   

}
