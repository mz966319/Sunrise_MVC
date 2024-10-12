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

        public int GradeID { get; set; }
        public IEnumerable<SelectListItem>? GradeList { get; set; }

        public int ClassID { get; set; }
        public IEnumerable<SelectListItem>? ClassList { get; set; }


    }
}
