using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherPermissionController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public TeacherPermissionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public IActionResult Index(string id)
        {
            TempData["UserID"]=id;
            TempData["UserName"] = _unitOfWork.ApplicationUser.Get(u => u.Id == id).FullName.ToString();
            List <TeacherPermission> objectTeacherPermissionsList = _unitOfWork.TeacherPermission.GetList(u=>u.UserID==id, includeProperties: "User,Subject,Class").ToList();
            Dictionary<int, List<TeacherPermission>> subjectMap = objectTeacherPermissionsList
            .GroupBy(tp => tp.SubjectID)
            .ToDictionary(g => g.Key, g => g.ToList());
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
                SubjectsList=_unitOfWork.Subject.GetList(u=>u.StaticFlag==false).OrderBy(u=>u.SubjectNameEN).Select(s => new SelectListItem
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
 
            if (ModelState.IsValid)
            {
                TeacherPermission teacherPermission = new()
                {
                    TeacherPermissionID = 0,
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
                return View();

        }
    }
}
