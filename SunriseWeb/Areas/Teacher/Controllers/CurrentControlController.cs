using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;
using Sunrise.Utility;
using System.Diagnostics;

namespace SunriseWeb.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin + "," + SD.Role_Teacher)]
    public class CurrentControlController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public CurrentControlController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            string CurrentUserID = user?.Id;
            var grades = GetGrades(CurrentUserID);
            CurrentControlViewModel currentControlViewModel = new()
            {
                CurrentUser = CurrentUserID,
                YearsList = _unitOfWork.Year.GetList(u => u.ActiveFlag).OrderByDescending(y => y.AddmissionDate).Select(u => new SelectListItem
                {
                    Text = "G:" + u.YearEN + " , H:" + u.YearAR,
                    Value = u.YearID.ToString()

                }),

                GradesList = grades.Select(u => new SelectListItem { Text = u.GradeName, Value = u.GradeID.ToString() }),
                CurrentControlList = new()// _unitOfWork.CurrentControl.GetAll( includeProperties: "Student").ToList()
            };
            return View(currentControlViewModel);
        }
        [HttpPost]
        public  IActionResult Index(CurrentControlViewModel VM)
        {

            VM.YearsList = _unitOfWork.Year.GetList(u => u.ActiveFlag).OrderByDescending(y => y.AddmissionDate).Select(u => new SelectListItem { Text = "G:" + u.YearEN + " , H:" + u.YearAR, Value = u.YearID.ToString()});
            VM.Semester = _unitOfWork.YearSemester.Get(u=> u.YearSemesterID==VM.SemesterID);
            VM.SemestersList = _unitOfWork.YearSemester.GetList(u => u.YearID == VM.YearID && u.ActiveFlag).ToList().Select(u => new SelectListItem { Text = u.SemesterNameEN+" - "+u.SemesterNameAR, Value = u.YearSemesterID.ToString() });
            VM.GradesList = GetGrades(VM.CurrentUser).Select(u => new SelectListItem { Text = u.GradeName, Value = u.GradeID.ToString()});
            VM.SubjectsList = GetSubjects(VM.CurrentUser, VM.GradeID).Select(u => new SelectListItem { Text = u.SubjectNameEN, Value = u.SubjectID.ToString() }); ;
            VM.ClassesList = GetClasses(VM.CurrentUser,VM.SubjectID, VM.GradeID).Select(u => new SelectListItem { Text = u.ClassName, Value = u.GradeClassID.ToString() }); ;
            VM.SemesterID = 2;

            if (ModelState.IsValid)
            {
                VM.CurrentControlList = _unitOfWork.CurrentControl.GetList(u => u.ClassID==VM.ClassID && u.SubjectID==VM.SubjectID && u.YearSemesterID==VM.Semester.YearSemesterID && u.Student.StudentActiveFlag==SD.Student_Status_Active, includeProperties: "Student,YearSemester").ToList();
                return View("Index",VM);
            }
            return RedirectToAction("Index", "CurrentControl");
        }

        [HttpPost]
        public IActionResult UpdateCurrentControlList(CurrentControlViewModel VM)
        {
            VM.YearsList = _unitOfWork.Year.GetList(u => u.ActiveFlag).OrderByDescending(y => y.AddmissionDate).Select(u => new SelectListItem { Text = "G:" + u.YearEN + " , H:" + u.YearAR, Value = u.YearID.ToString() });
            VM.Semester = _unitOfWork.YearSemester.Get(u => u.YearSemesterID == VM.SemesterID);
            VM.SemestersList = _unitOfWork.YearSemester.GetList(u => u.YearID == VM.YearID && u.ActiveFlag).ToList().Select(u => new SelectListItem { Text = u.SemesterNameEN, Value = u.YearSemesterID.ToString() });
            VM.GradesList = GetGrades(VM.CurrentUser).Select(u => new SelectListItem { Text = u.GradeName, Value = u.GradeID.ToString() });
            VM.SubjectsList = GetSubjects(VM.CurrentUser, VM.GradeID).Select(u => new SelectListItem { Text = u.SubjectNameEN, Value = u.SubjectID.ToString() }); ;
            VM.ClassesList = GetClasses(VM.CurrentUser, VM.SubjectID, VM.GradeID).Select(u => new SelectListItem { Text = u.ClassName, Value = u.GradeClassID.ToString() }); ;
            foreach (var item in VM.CurrentControlList)
            {
                item.Student= _unitOfWork.Student.Get(u=>u.StudentID==item.StudentID.ToString()); 
            }
            if (ModelState.IsValid)
            {
                List<CurrentControl> controlsToUpdate = VM.CurrentControlList;
                _unitOfWork.CurrentControl.UpdateRange(controlsToUpdate);

                _unitOfWork.Save();
                TempData["success"] = "records updated successfully";
                VM.CurrentControlList = _unitOfWork.CurrentControl.GetList(u => u.ClassID == VM.ClassID && u.SubjectID == VM.SubjectID && u.YearSemesterID == VM.SemesterID && u.Student.StudentActiveFlag == SD.Student_Status_Active, includeProperties: "Student").ToList();
                return View("Index",VM);
            }
            return RedirectToAction("Index", "CurrentControl");
        }





        public JsonResult GetCurrentControlList(int yearId, int semesterId, int subjectId, int classId)
        {
            List<CurrentControl> currentControls = _unitOfWork.CurrentControl.GetList(u => u.YearSemester.YearID == yearId && u.YearSemesterID == semesterId
            && u.SubjectID == subjectId && u.ClassID == classId && u.Student.StudentActiveFlag==0, includeProperties: "YearSemester,Student").ToList();

            return Json(currentControls);
        }

        public List<Grade> GetGrades(string CurrentUserID)
        {

            List<TeacherPermission> teacherPermissions = _unitOfWork.TeacherPermission.GetList(u => u.UserID == CurrentUserID).ToList();

            List<Grade> grades = _unitOfWork.Grade.GetAll().ToList();
            List<Grade> filteredGrades = new();
            if (User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Super_Admin))
            {
                filteredGrades = grades;
            }
            else
            {
                foreach (var grade in grades)
                {
                    TeacherPermission checkPermission = _unitOfWork.TeacherPermission.Get(u => u.UserID == CurrentUserID && u.Class.GradeID == grade.GradeID, includeProperties: "Class");
                    if (checkPermission != null)
                    {
                        filteredGrades.Add(grade);
                    }
                }
            }
            return filteredGrades.ToList();
        }

        public List<Subject> GetSubjects(string CurrentUserID, int gradeId)
        {
            List<TeacherPermission> teacherPermissions = _unitOfWork.TeacherPermission.GetList(u => u.UserID == CurrentUserID && u.Class.GradeID == gradeId, includeProperties: "Class").ToList();
            List<Subject> subjects;
            if (gradeId > 3)
            {
                subjects = _unitOfWork.Subject.GetList(u => !u.StaticFlag).ToList();
            }
            else
            {
                subjects = _unitOfWork.Subject.GetList(u => u.SubjectID == 1 || u.SubjectID == 2 || u.SubjectID == 4
                                                        || u.SubjectID == 6 || u.SubjectID == 11).ToList();
            }
            List<Subject> filteredSubjects = new();
            if (User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Super_Admin))
            {
                filteredSubjects = subjects;
            }
            else
            {
                foreach (var subject in subjects)
                {
                    TeacherPermission checkPermission = _unitOfWork.TeacherPermission.Get(u => u.UserID == CurrentUserID && u.Class.GradeID == gradeId && u.SubjectID == subject.SubjectID, includeProperties: "Class");
                    if (checkPermission != null)
                    {
                        filteredSubjects.Add(subject);
                    }
                }
            }
            return filteredSubjects;
        }

        
        public List<GradeClass> GetClasses(String CurrentUserID, int subjectId, int gradeId)
        {
            List<TeacherPermission> teacherPermissions = _unitOfWork.TeacherPermission.GetList(u => u.UserID == CurrentUserID && u.SubjectID == subjectId && u.Class.GradeID == gradeId, includeProperties: "Class").ToList();
            List<GradeClass> classes = _unitOfWork.GradeClass.GetList(u => u.GradeID == gradeId).ToList();
            List<GradeClass> filteredClasses = new();
            if (User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Super_Admin))
            {
                filteredClasses = classes;
            }
            else
            {
                foreach (var classItem in classes)
                {
                    TeacherPermission checkPermission = _unitOfWork.TeacherPermission.Get(u => u.UserID == CurrentUserID && u.SubjectID == subjectId && u.Class.GradeID == gradeId && u.ClassID == classItem.GradeClassID, includeProperties: "Class");
                    if (checkPermission != null)
                    {
                        filteredClasses.Add(classItem);
                    }
                }
            }
            return filteredClasses;
        }

        public JsonResult GetSemesterByYearID(int yearId)
        {
            List<YearSemester> objectSemesterList = _unitOfWork.YearSemester.GetList(u => u.YearID == yearId && u.ActiveFlag ).ToList();
            return Json(objectSemesterList);
        }





        public async Task<JsonResult> GetSubjectByGradeIDAsync(int gradeId)
        {
            var user = await _userManager.GetUserAsync(User);
            string CurrentUserID = user?.Id;
            return Json(GetSubjects(CurrentUserID, gradeId));
        }

        public async Task<JsonResult> GetClassByGradeIDAsync(int subjectId, int gradeId)
        {
            var user = await _userManager.GetUserAsync(User);
            string CurrentUserID = user?.Id;
            return Json(GetClasses(CurrentUserID, subjectId, gradeId));
        }

    }
}
