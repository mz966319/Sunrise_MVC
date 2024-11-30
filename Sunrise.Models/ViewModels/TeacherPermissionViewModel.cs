using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models.ViewModels
{
    public class TeacherPermissionViewModel
    {
        public string UserID { get; set; }
        [DisplayName("Subject")]
        public int SubjectID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SubjectsList { get; set; }
        //[DisplayName("Grade")]
        public int GradeID { get; set; }
        //[ValidateNever]
        public IEnumerable<SelectListItem>? GradesList { get; set; }
        [DisplayName("Class")]
        public int ClassID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? ClassesList { get; set; }

        public string PermissionType { get; set; }


    }
}
