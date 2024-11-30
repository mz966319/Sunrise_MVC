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
    public class CurrentControl
    {
        [Key]
        public int CurrentControlID { get; set; }

        public int YearSemesterID { get; set; }

        [ForeignKey("YearSemesterID")]
        [ValidateNever]
        public YearSemester? YearSemester { get; set; }


        public int ClassID { get; set; }
       
        public string StudentID { get; set; }

        [ForeignKey("StudentID")]
        [ValidateNever]
        public Student? Student { get; set; }

        public int SubjectID { get; set; }

        [ForeignKey("SubjectID")]
        [ValidateNever]
        public Subject? Subject { get; set; }

        [DisplayName("Quiz 1")]
        [Range(0, 20, ErrorMessage = "0 - 20")]
        public int Quiz1 { get; set; }

        [DisplayName("Quiz 2")]
        [Range(0, 10, ErrorMessage = "0 - 10")]
        public int? Quiz2 { get; set; }

        [DisplayName("Quiz 3")]
        public int? Quiz3 { get; set; }

        [Required]
        [DisplayName("Class Work")]
        [Range(0, 15, ErrorMessage = "0 - 15")]

        public int ClassWork { get; set; } = 0;

        [Required]
        [DisplayName("Home Work")]
        [Range(0, 15, ErrorMessage = "0 - 15")]
        public int HomeWork { get; set; } = 0;

        public int? Behaviour { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "0 - 10")]
        public int Project { get; set; } = 0;

        public int? Practical { get; set; }

        [Required]
        [DisplayName("Exam Mark")]
        [Range(0, 40, ErrorMessage = "0 - 40")]

        public int ExamMark { get; set; }= 0;
        [Required]
        public bool Absent { get; set; }



        

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //        return false;

        //    YearSemester other = (YearSemester)obj;
        //    return YearSemesterID == other.YearSemesterID && SemesterNumber == other.SemesterNumber
        //        && SemesterNameEN == other.SemesterNameEN && SemesterNameAR == other.SemesterNameAR
        //        && FinalMark == other.FinalMark && ActiveFlag == other.ActiveFlag
        //        && YearID == other.YearID;
        //}
    }
}
