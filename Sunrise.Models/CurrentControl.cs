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


        public int GradeID { get; set; }

        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        [ValidateNever]
        public Student? Student { get; set; }

        public int SubjectID { get; set; }

        [ForeignKey("SubjectID")]
        [ValidateNever]
        public Subject? Subject { get; set; }

        [Required]
        [DisplayName("Quiz 1")]
        public int Quiz1 { get; set; }

        [Required]
        [DisplayName("Quiz 2")]
        public int Quiz2 { get; set; }

        [Required]
        [DisplayName("Quiz 3")]
        public int Quiz3 { get; set; }

        [Required]
        [DisplayName("Class Work")]
        public int ClassWork { get; set; }

        [Required]
        [DisplayName("Home Work")]
        public int HomeWork { get; set; }

        [Required]
        public int Behaviour { get; set; }

        [Required]
        public int Project { get; set; }

        [Required]
        public int Practical { get; set; }

        [Required]
        [DisplayName("Exam Mark")]
        public int ExamMark { get; set; }
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
