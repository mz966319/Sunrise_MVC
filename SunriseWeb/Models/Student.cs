using Microsoft.AspNetCore.Http.HttpResults;
using SunriseWeb.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SunriseWeb.Models
{
    public class Student
    {
        [Key]
        [DisplayName("Student ID")]
        public int StudentID { get; set; }


        [Required]
        [DisplayName("Student Name")]
        public String StudentNameEN { get; set; }


        [Required]
        [DisplayName("اسم الطالب")]
        public String StudentNameAR { get; set; }

        [DisplayName("Nationality ID")]
        public int NationalityID { get; set; }

        //[DisplayName("Nationality")]
        //public String NationalityEN { get; set; }


        //[DisplayName("الجنسية")]
        //public String NationalityAR { get; set; }


        [DisplayName("رقم الهوية\nالاقامة")]
        public String IDNumber { get; set; }


        [DisplayName("ID/Iqama Expire Date")]
        public DateOnly IDEndDate { get; set; }


        [DisplayName("Passport Number")]
        public String Passport {  get; set; }


        [DisplayName("Passport Expire Date")]
        public DateOnly PassportEndDate { get; set; }


        [DisplayName("Admission Date")]
        public DateOnly AdmissionDate {  get; set; }


        [DisplayName("Previous School")]
        public String PreviousSchoolEN {  get; set; }


        [DisplayName("المدرسة السابقة")]
        public String PreviousSchoolAR { get;set; }


        [DisplayName("Birth Date")]
        public DateOnly BirthDate { get; set; }


        [DisplayName("Current Class")]
        public int CurrentClassID {  get; set; }


        [DisplayName("Current Grade")]
        public int CurrentGradeID { get; set;}


        [DisplayName("Gender")]
        public String Gender { get; set; }


        public int StudentActiveFlag { get; set; } //0=active 1=Discontinued 2=withdrawal

        public int AuditorFlag { get; set; } //0 = normal 1 = auditor

        [DisplayName("Phone Number 1")]
        public String PhoneNumber1 { get; set; }


        [DisplayName("Phone Number 1")]
        public String PhoneNumber2 { get; set;}

        [DisplayName("Place of Birth ID")]
        public int BirthPlaceID { get; set; }

        //[DisplayName("Place of Birth")]
        //public String BirthPlaceEN { get; set; }


        //[DisplayName("مكان الميلاد")]
        //public String BirthPlaceAR {  get; set; }


        public DateTime DateCreated {  get; set; }
        public DateTime DateUpdated { get; set; }
        public String CreatedBy { get; set; }
        public String UpdatedBy { get; set;}



    }
}
