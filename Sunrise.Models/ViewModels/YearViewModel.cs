using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models.ViewModels
{
    public class YearViewModel
    {
        public string CurrentUser { get; set; }
        public Year Year {  get; set; }
        public List<YearSemester> Semesters { get; set; }
        //public List<YearManager> Managers { get; set; }


        //public IEnumerable<SelectListItem> NationalityList { get; set; }
        //public IEnumerable<SelectListItem> CountryList { get; set; }
        //public IEnumerable<SelectListItem> PreviousSchoolList { get; set; }
        //public IEnumerable<SelectListItem> BusList { get; set; }

        //public int GradeID { get; set; }
        //public IEnumerable<SelectListItem>? GradeList { get; set; }

        //public int ClassID { get; set; }
        //public IEnumerable<SelectListItem>? ClassList { get; set; }


    }
}
