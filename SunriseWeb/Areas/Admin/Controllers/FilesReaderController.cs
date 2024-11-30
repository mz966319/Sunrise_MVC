using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sunrise.DataAccess.Data;
using Sunrise.DataAccess.Repository.IRepository;
using Sunrise.Models;
using Sunrise.Models.ViewModels;
using Sunrise.Utility;

namespace SunriseWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Super_Admin)]
    public class FilesReaderController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public FilesReaderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult UploadExcel(IFormFile file, string activeTab)
        {
            var viewModel = new UploadViewModel
            {
                ActiveTab = activeTab,
                ToAddStudentsList = new List<Student>() // Default empty list
            };

            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("File", "Please upload a valid file.");
                return View("Index", viewModel);
            }

            // Save the uploaded file to a temporary path
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            try
            {
                // Use ReadExcelFiles to extract data
                var students = ReadExcelFiles.AddStudentsFromMatex(filePath);
            

            // Clean up the file after processing (optional)
            System.IO.File.Delete(filePath);

            // Populate the ViewModel
            viewModel.ToAddStudentsList = students;
            viewModel.UploadedFileName = file.FileName;
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error reading the file";
            }
            return View("Index", viewModel);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(new UploadViewModel
            {
                ToAddStudentsList = new List<Student>(),
                ActiveTab = ""
            });
        }
    }
}
