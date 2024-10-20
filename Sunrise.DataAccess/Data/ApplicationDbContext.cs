using Microsoft.EntityFrameworkCore;
using Sunrise.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Sunrise.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet <Country> Countries { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Bus> Busses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeClass> GradeClasses { get; set; }
        public DbSet<PreviousSchool> PreviousSchools { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<YearManager> YearManagers { get; set; }
        public DbSet<YearSemester> YearSemesters { get; set; }
        public DbSet<CurrentControl> CurrentControls{ get; set; }
        public DbSet<TeacherPermission> TeacherPermissions { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                    new Country
                    {
                        CountryID = 1,
                        CountryNameEN = "Moaz",
                        CountryNameAR = "معاذ",
                        //NationalityEN = "Egypt",
                        //NationalityARMale = "مصر",
                        //NationalityARFemale = "12"

                    }
                );
            modelBuilder.Entity<Nationality>().HasData(
                new Nationality
                {
                    NationalityID = 1,
                    NationalityEN = "Egypt",
                    NationalityARMale = "مصر",
                    NationalityARFemale = "12"
                }
            );
            modelBuilder.Entity<Bus>().HasData(
                new Bus
                {
                    BusID = 1,
                    BusNumber = 1,
                    DriverName = "Mo",
                    DriverPhone = "0500",
                    BusPlate = "ABC",
                    BusPath = "Shemesi",
                    BusType="Hilox"
                }
            );

            modelBuilder.Entity<PreviousSchool>().HasData(
                new PreviousSchool
                {
                    PreviousSchoolID = 1,
                    PreviousSchoolNameAR = "مدارس شروق الشمس العالمية",
                    PreviousSchoolNameEN = "Sunrise International Schools",
                }
            );
            modelBuilder.Entity<GradeClass>().HasData(
                new GradeClass
                {
                    GradeClassID = 1,
                    ClassName = "BA",
                    GradeID = 1
                }
            );



            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    SubjectID = 1,
                    SubjectNameEN = "Islamic St.",
                    SubjectNameAR = "الدراسات الإسلامية",
                    NoorName = "القرآن الكريم والدراسات الإسلامية",
                    NoorID = 291,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 2,
                    SubjectNameEN = "Arabic",
                    SubjectNameAR = "اللغة العربية",
                    NoorName = "اللغة العربية",
                    NoorID = 157,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 3,
                    SubjectNameEN = "Social Studies",
                    SubjectNameAR = "الإجتماعيات",
                    NoorName = "الإجتماعيات",
                    NoorID = 289,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 4,
                    SubjectNameEN = "English",
                    SubjectNameAR = "اللغة الإنجليزية",
                    NoorName = "اللغة الإنجليزية",
                    NoorID = 14,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 5,
                    SubjectNameEN = "French",
                    SubjectNameAR = "اللغة الفرنسية",
                    NoorName = "اللغة الفرنسية",
                    NoorID = 200548,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 11,
                    SubjectNameEN = "Mathematics",
                    SubjectNameAR = "الرياضيات",
                    NoorName = "الرياضيات",
                    NoorID = 16,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 12,
                    SubjectNameEN = "Social Studies (Eng)",
                    SubjectNameAR = "الاجتماعيات (بالانجليزي)",
                    NoorName = "اجتماعيات باللغة الانجليزية",
                    NoorID = 201110,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 14,
                    SubjectNameEN = "Computer",
                    SubjectNameAR = "الحاسب الآلي",
                    NoorName = "الحاسب الآلي",
                    NoorID = 46,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 6,
                    SubjectNameEN = "Science",
                    SubjectNameAR = "العلوم",
                    NoorName = "العلوم",
                    NoorID = 74,
                    StaticFlag = false
                },
                new Subject
                {
                    SubjectID = 15,
                    SubjectNameEN = "Physical Education",
                    SubjectNameAR = "التربية البدنية",
                    NoorName = "التربية البدنية",
                    NoorID = 30,
                    StaticFlag = true
                },
                new Subject
                {
                    SubjectID = 16,
                    SubjectNameEN = "Conduct",
                    SubjectNameAR = "السلوك",
                    NoorName = "السلوك",
                    NoorID = 0,
                    StaticFlag = true
                },
                new Subject
                {
                    SubjectID = 17,
                    SubjectNameEN = "Attendance",
                    SubjectNameAR = "المواظبة",
                    NoorName = "المواظبة",
                    NoorID = 0,
                    StaticFlag = true
                }
            );





            modelBuilder.Entity<Grade>().HasData(
                new Grade
                {
                    GradeID = 1,
                    GradeName = "KG 1",
                    SchoolName = "G",
                    CertificateNameAR = "روضة أول",
                    CertificateNameEN = "Kindergarten first grade",
                    GradeLevel = -1
                },
                new Grade
                {
                    GradeID = 2,
                    GradeName = "KG 2",
                    SchoolName = "G",
                    CertificateNameAR = "روضة ثاني",
                    CertificateNameEN = "Kindergarten Seconde grade",
                    GradeLevel = -2
                },
                new Grade
                {
                    GradeID = 3,
                    GradeName = "KG 3",
                    SchoolName = "G",
                    CertificateNameAR = "روضة ثالث",
                    CertificateNameEN = "Kindergarten Third grade",
                    GradeLevel = -3
                },
                new Grade
                {
                    GradeID = 4,
                    GradeName = "Grad 1",
                    SchoolName = "G",
                    CertificateNameAR = "الصف الأول الابتدائى",
                    CertificateNameEN = "Elementary first grade",
                    GradeLevel = 1
                },
                new Grade
                {
                    GradeID = 5,
                    GradeName = "Grad 2",
                    SchoolName = "G",
                    CertificateNameAR = "الصف الثانى الابتدائى",
                    CertificateNameEN = "Elementary Seconde grade",
                    GradeLevel = 2
                },
                new Grade
                {
                    GradeID = 6,
                    GradeName = "Grad 3",
                    SchoolName = "G",
                    CertificateNameAR = "الصف الثالث الابتدائى",
                    CertificateNameEN = "Elementary Third grade",
                    GradeLevel = 3
                },
                new Grade
                {
                    GradeID = 7,
                    GradeName = "Grad 4 B",
                    SchoolName = "B",
                    CertificateNameAR = "الصف الرابع الابتدائى",
                    CertificateNameEN = "Elementary Fourth grade",
                    GradeLevel = 4
                },
                new Grade
                {
                    GradeID = 8,
                    GradeName = "Grad 4 G",
                    SchoolName = "G",
                    CertificateNameAR = "الصف الرابع الابتدائي",
                    CertificateNameEN = "Elementary Fourth grade",
                    GradeLevel = 4
                },
                new Grade
                {
                    GradeID = 9,
                    GradeName = "Grad 5 B",
                    SchoolName = "B",
                    CertificateNameAR = "الصف الخامس الابتدائى",
                    CertificateNameEN = "Elementary Fifth grade",
                    GradeLevel = 5
                },
                new Grade
                {
                    GradeID = 10,
                    GradeName = "Grad 5 G",
                    SchoolName = "G",
                    CertificateNameAR = "الصف الخامس الابتدائى",
                    CertificateNameEN = "Elementary Fifth grade",
                    GradeLevel = 5
                },
                new Grade
                {
                    GradeID = 11,
                    GradeName = "Grad 6 B",
                    SchoolName = "B",
                    CertificateNameAR = "الصف السادس الابتدائى",
                    CertificateNameEN = "Elementary Sixth grade",
                    GradeLevel = 6
                },
                new Grade
                {
                    GradeID = 12,
                    GradeName = "Grad 6 G",
                    SchoolName = "G",
                    CertificateNameAR = "الصف السادس الابتدائى",
                    CertificateNameEN = "Elementary Sixth grade",
                    GradeLevel = 6
                },
                new Grade
                {
                    GradeID = 13,
                    GradeName = "Grad 7 B",
                    SchoolName = "B",
                    CertificateNameAR = "الصف الأول المتوسط",
                    CertificateNameEN = "Intermediate First grade",
                    GradeLevel = 7
                },
                new Grade
                {
                    GradeID = 14,
                    GradeName = "Grad 7 G",
                    SchoolName = "G",
                    CertificateNameAR = "الصف الأول المتوسط",
                    CertificateNameEN = "Intermediate First grade",
                    GradeLevel = 7
                },
                new Grade
                {
                    GradeID = 15,
                    GradeName = "Grad 8 B",
                    SchoolName = "B",
                    CertificateNameAR = "الصف الثانى المتوسط",
                    CertificateNameEN = "Intermediate Second grade",
                    GradeLevel = 8
                },
                new Grade
                {
                    GradeID = 16,
                    GradeName = "Grad 8 G",
                    SchoolName = "G",
                    CertificateNameAR = "الصف الثانى المتوسط",
                    CertificateNameEN = "Intermediate Second grade",
                    GradeLevel = 8
                },
                new Grade
                {
                    GradeID = 17,
                    GradeName = "Grad 9 B",
                    SchoolName = "B",
                    CertificateNameAR = "الصف الثالث المتوسط",
                    CertificateNameEN = "Intermediate third grade",
                    GradeLevel = 9
                },
                new Grade
                {
                    GradeID = 18,
                    GradeName = "Grad 9 G",
                    SchoolName = "G",
                    CertificateNameAR = "الصف الثالث المتوسط",
                    CertificateNameEN = "Intermediate third grade",
                    GradeLevel = 9
                }
            );
            modelBuilder.Entity<Year>().HasData(
                new Year
                {
                    YearID=1,
                     YearEN="2020-2021",
                    YearAR="1444-1445" ,
                    AddmissionDate= DateOnly.FromDateTime(DateTime.UtcNow),
                    ActiveFlag=true
                }
            );
            modelBuilder.Entity<YearManager>().HasData(
                new YearManager
                {
                    YearManagerID=1,
                    SchoolManagerEN="mo",
                    SchoolManagerAR="مع",
                    ControlManagerEN = "az",
                    ControlManagerAR = "اذ",
                    GradeID = 1,
                    YearID = 1
                }
            );
            modelBuilder.Entity<YearSemester>().HasData(
                new YearSemester
                {
                    YearSemesterID = 1,
                    SemesterNumber=1,
                    SemesterNameEN = "First Semester",
                    SemesterNameAR = "الفصل الدراسي الأول",
                    QuizCount = 2,
                     FinalMark = 25,
                    ActiveFlag = true,
                    YearID = 1
                }
            );
            modelBuilder.Entity<Student>().HasData(
                    new Student
                    {
                        StudentID = 1,
                        StudentNameEN = "Moaz",
                        StudentNameAR = "معاذ",
                        NationalityID = 1,
                        IDNumber = "12",
                        IDEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        Passport = "A12",
                        PassportEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        AdmissionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        PreviousSchoolID = 1,
                        BirthDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        CurrentClassID = 1,
                        StudentActiveFlag = 0,
                        Gender = "Male",
                        ParentPhone1 = "111",
                        ParentPhones2 = "222",
                        StudentPhone = "333",
                        BirthPlaceID = 1,
                        DateCreated = DateTime.Now,
                        CreatedBy = "moaz",
                        BusID=1,
                        BusSubscription="ذهاب"

                    }
                );

        modelBuilder.Entity<CurrentControl>().HasData(
                new CurrentControl
                {
                    CurrentControlID = 1,
                    YearSemesterID = 1,
                    GradeID = 1,
                    StudentID = 1,
                    SubjectID = 1,
                    Quiz1 = 1,
                    Quiz2 = 2,
                    Quiz3 = 3,
                    HomeWork=3,
                    Behaviour =5,
                    Project =7,
                    Practical =9,
                    ExamMark =0,
                    Absent = true
                }
            );
        }

    }
}
