using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sunrise.Models
{
    public class YearSemester
    {
        [Key]
        public int YearSemesterID { get; set; }

        [Required]
        [DisplayName("Semester Number")]
        public int SemesterNumber { get; set; }
        [Required]
        [DisplayName("Semester Name")]
        public string SemesterNameEN { get; set; }
        [Required]
        [DisplayName("اسم مدير/ة المدرسة")]
        public string SemesterNameAR { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Number of Quizzes must be between 1 and 3")]
        [DisplayName("# of Quizzes")]
        public int QuizCount { get; set; }

        [Required]
        [DisplayName("Final Mark")]
        public int FinalMark { get; set; }

        [Required]
        [DisplayName("Active")]
        public bool ActiveFlag { get; set; }

        public int YearID { get; set; }

        [ForeignKey("YearID")]
        [ValidateNever]
        public Year? Year { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            YearSemester other = (YearSemester)obj;
            return YearSemesterID == other.YearSemesterID && SemesterNumber == other.SemesterNumber
                && SemesterNameEN == other.SemesterNameEN && SemesterNameAR == other.SemesterNameAR
                && FinalMark == other.FinalMark && ActiveFlag == other.ActiveFlag
                && YearID == other.YearID;
        }
    }
}
