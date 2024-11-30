using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models.ViewModels
{
    public class StudentViewModel
    {
        public string CurrentUser { get; set; }
        public Student Student {  get; set; }
        public IEnumerable<SelectListItem> NationalityList { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public IEnumerable<SelectListItem> PreviousSchoolList { get; set; }
        public IEnumerable<SelectListItem> BusList { get; set; }

        public int CurrentGradeID { get; set; }
        public IEnumerable<SelectListItem>? CurrentGradeList { get; set; }

        public int CurrentClassID { get; set; }
        public IEnumerable<SelectListItem>? CurrentClassList { get; set; }

        public int TmpGradeID { get; set; }
        public IEnumerable<SelectListItem>? TmpGradeList { get; set; }

        public int TmpClassID { get; set; }
        public IEnumerable<SelectListItem>? TmpClassList { get; set; }
    }
}
