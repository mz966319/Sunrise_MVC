using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models
{
    public class PreviousSchool
    {
        [Key]
        public int PreviousSchoolID { get; set; }
        [Required]
        [DisplayName("Previous School Name EN")]
        public string PreviousSchoolNameEN { get; set;}

        [Required]
        [DisplayName("اسم المدرسة")]
        public string PreviousSchoolNameAR { get; set;}
    }
}
