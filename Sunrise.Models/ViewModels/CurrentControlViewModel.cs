﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models.ViewModels
{
    public class CurrentControlViewModel
    {
        public string CurrentUser { get; set; }
        //public Student Curr {  get; set; }
        public int YearID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> YearsList { get; set; }
        public int SemesterID { get; set; }
        [ValidateNever]
        public YearSemester Semester { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SemestersList { get; set; }
        public int SubjectID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SubjectsList { get; set; }
        public int GradeID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? GradesList { get; set; }
        public int ClassID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? ClassesList { get; set; }

        [ValidateNever]
        public List<CurrentControl> CurrentControlList { get; set; }





    }
}
