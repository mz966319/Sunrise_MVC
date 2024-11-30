using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sunrise.Models.ViewModels
{
    public class ControlReportsViewModel
    {

        public int YearID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> YearsList { get; set; }
        public int SemesterID { get; set; }
        [ValidateNever]
        public YearSemester Semester { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SemestersList { get; set; }
        public int GradeID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? GradesList { get; set; }
        [ValidateNever]
        public int ClassID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? ClassesList { get; set; }

        [ValidateNever]
        public string StudentID { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> StudentsList { get; set; }

    }
}
