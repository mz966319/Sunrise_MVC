using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models
{
    public class YearManager
    {
        [Key]
        public int YearManagerID { get; set; }

        [Required]
        [DisplayName("School Manager Name")]
        public string? SchoolManagerEN { get; set; }

        [Required]
        [DisplayName("اسم مدير/ة المدرسة")]
        public string? SchoolManagerAR { get; set; }

        [Required]
        [DisplayName("Control Manager Name")]
        public string? ControlManagerEN { get; set; }

        [Required]
        [DisplayName("اسم مدير/ة الرصد")]
        public string? ControlManagerAR { get; set; }

        public int GradeID { get; set; }

        [ForeignKey("GradeID")]
        [ValidateNever]
        public Grade? Grade { get; set; }

        public int YearID { get; set; }

        [ForeignKey("YearID")]
        [ValidateNever]
        public Year? Year { get; set; }
    }
}
