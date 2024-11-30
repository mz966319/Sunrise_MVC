using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sunrise.Models
{
    public class Student
    {
        [Key]
        [DisplayName("Student ID")]
        [ValidateNever]
        public string? StudentID { get; set; }


        [Required]
        [DisplayName("Student Name")]
        public string StudentNameEN { get; set; }


        [Required]
        [DisplayName("اسم الطالب")]
        public string StudentNameAR { get; set; }
 

        [DisplayName("رقم الهوية\nالاقامة")]
        public string? IDNumber { get; set; }


        [DisplayName("ID/Iqama Expire Date")]
        public DateOnly? IDEndDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow); //set defult to today


        [DisplayName("Passport Number")]
        public string? Passport { get; set; }


        [DisplayName("Passport Expire Date")]
        public DateOnly? PassportEndDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow); //set defult to today


        [DisplayName("Admission Date")]
        public DateOnly? AdmissionDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow); //set defult to today


        [DisplayName("Birth Date")]
        public DateOnly? BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow); //set defult to today




        [DisplayName("Gender")]
        public string? Gender {get; set;}


        public int StudentActiveFlag {get; set;} //0=active 1=Discontinued 2=withdrawal

        public bool AuditorFlag { get; set; } //0 = normal 1 = auditor

        [DisplayName("Parent Phone 1")]
        public string ParentPhone1 {get; set;}


        [DisplayName("Parent phone 2")]
        public string? ParentPhones2 { get; set; }

        [DisplayName("Student Phone")]
        public string? StudentPhone {get; set;}

        [DisplayName("Matex Student ID")]
        public int? MatexStudentID {get; set;}

        [DisplayName("Matex Parent ID")]
        public int? MatexParentID {get; set;}
        public bool BusFlag { get; set; }

        public bool TmpFlag { get; set; }

        public bool BlockFlag {  get; set; }

        [DisplayName("Bus Subscription")]
        public string? BusSubscription { get; set;}

        public DateTime DateCreated {get; set;}
        public DateTime? DateUpdated { get; set;}
        public string CreatedBy {get; set;}
        public string? UpdatedBy {get; set;}
   



        [DisplayName("Nationality")]
        public int? NationalityID { get; set; }
        [ForeignKey("NationalityID")]
        public virtual Nationality? Nationality { get; set; }



        [DisplayName("Place of Birth ID")]
        public int? BirthPlaceID { get; set; }
        [ForeignKey("BirthPlaceID")]//link foreign key to the id and the model
        [ValidateNever]
        public virtual Country? CountryBirth { get; set; }



        [DisplayName("Previous School")]
        public int? PreviousSchoolID { get; set; }
        [ForeignKey("PreviousSchoolID")]//link foreign key to the id and the model
        [ValidateNever]
        public virtual PreviousSchool? PreviousSchool { get; set; }


        [DisplayName("Current Class")]
        public int CurrentClassID { get; set; }
        [ForeignKey("CurrentClassID")]//link foreign key to the id and the model
        [ValidateNever]
        public virtual GradeClass? CurrentClass { get; set; }


        [DisplayName("Temporary Class")]
        public int? TemporaryClassID { get; set; }
        [ForeignKey("TemporaryClassID")]//link foreign key to the id and the model
        [ValidateNever]
        public virtual GradeClass? TemporaryClass { get; set; }

        [DisplayName("Bus")]
        public int? BusID { get; set; }
        [ForeignKey("BusID")]//link foreign key to the id and the model
        [ValidateNever]
        public virtual Bus? Bus { get; set; }



        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Student other = (Student)obj;
            return StudentID == other.StudentID;
        }

        public override string? ToString()
        {
            return StudentNameAR + " " + MatexParentID +" " + MatexStudentID;
        }

        //public override string ToString()
        //{
        //    return $"{StudentNameEN},{CurrentClassID}";
        //}

        //[DisplayName("Current Grade")]
        //public int CurrentGradeID { get; set; }
        //[ForeignKey("CurrentGradeID")]
        //[ValidateNever]
        //public virtual Grade? CurrentGrade { get; set; }






    }
}
