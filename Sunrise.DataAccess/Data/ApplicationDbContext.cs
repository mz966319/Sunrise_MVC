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
                        CountryNameEN = "Egypt",
                        CountryNameAR = "مصر"
                    },
                    new Country
                    {
                        CountryID = 2,
                        CountryNameEN = "Saudi Arabia",
                        CountryNameAR = "السعودية"
                    },
                    new Country
                    {
                        CountryID = 3,
                        CountryNameEN = "Palestine",
                        CountryNameAR = "فلسطين"
                    },
                    new Country
                    {
                        CountryID = 4,
                        CountryNameEN = "Yemen",
                        CountryNameAR = "اليمن"
                    },
                    new Country
                    {
                        CountryID = 5,
                        CountryNameEN = "Sudan",
                        CountryNameAR = "السودان"
                    },
                    new Country
                    {
                        CountryID = 6,
                        CountryNameEN = "Nigeria",
                        CountryNameAR = "نيجيريا"
                    },
                    new Country
                    {
                        CountryID = 7,
                        CountryNameEN = "Lebanon",
                        CountryNameAR = "لبنان"
                    },
                    new Country
                    {
                        CountryID = 8,
                        CountryNameEN = "Eritrea",
                        CountryNameAR = "إرتريا"
                    },
                    new Country
                    {
                        CountryID = 9,
                        CountryNameEN = "Turkey",
                        CountryNameAR = "تركيا"
                    },
                    new Country
                    {
                        CountryID = 10,
                        CountryNameEN = "Jordan",
                        CountryNameAR = "الأردن"
                    },
                    new Country
                    {
                        CountryID = 11,
                        CountryNameEN = "Morocco",
                        CountryNameAR = "المغرب"
                    },
                    new Country
                    {
                        CountryID = 12,
                        CountryNameEN = "United Kingdom",
                        CountryNameAR = "بريطانيا"
                    },
                    new Country
                    {
                        CountryID = 13,
                        CountryNameEN = "Syria",
                        CountryNameAR = "سوريا"
                    },
                    new Country
                    {
                        CountryID = 14,
                        CountryNameEN = "Kenya",
                        CountryNameAR = "كينيا"
                    },
                    new Country
                    {
                        CountryID = 15,
                        CountryNameEN = "Somalia",
                        CountryNameAR = "الصومال"
                    },
                    new Country
                    {
                        CountryID = 16,
                        CountryNameEN = "Chad",
                        CountryNameAR = "تشاد"
                    },
                    new Country
                    {
                        CountryID = 17,
                        CountryNameEN = "Afghanistan",
                        CountryNameAR = "أفغانستان"
                    },
                    new Country
                    {
                        CountryID = 18,
                        CountryNameEN = "Mali",
                        CountryNameAR = "مالي"
                    },
                    new Country
                    {
                        CountryID = 19,
                        CountryNameEN = "Pakistan",
                        CountryNameAR = "باكستان"
                    },
                    new Country
                    {
                        CountryID = 20,
                        CountryNameEN = "India",
                        CountryNameAR = "الهند"
                    },
                    new Country
                    {
                        CountryID = 21,
                        CountryNameEN = "United States of America",
                        CountryNameAR = "الولايات المتحدة الأمريكية"
                    },
                    new Country
                    {
                        CountryID = 22,
                        CountryNameEN = "Ethiopia",
                        CountryNameAR = "إثيوبيا"
                    },
                    new Country
                    {
                        CountryID = 23,
                        CountryNameEN = "Tunisia",
                        CountryNameAR = "تونس"
                    },
                    new Country
                    {
                        CountryID = 24,
                        CountryNameEN = "Algeria",
                        CountryNameAR = "الجزائر"
                    }
                );
            modelBuilder.Entity<Nationality>().HasData(
                new Nationality
                {
                    NationalityID = 1,
                    NationalityEN = "Egyptian",
                    NationalityARMale = "مصري",
                    NationalityARFemale = "مصرية"
                },
                new Nationality
                {
                    NationalityID = 2,
                    NationalityEN = "Saudi",
                    NationalityARMale = "سعودي",
                    NationalityARFemale = "سعودية"
                },
                new Nationality
                {
                    NationalityID = 3,
                    NationalityEN = "Palestinian",
                    NationalityARMale = "فلسطيني",
                    NationalityARFemale = "فلسطينية"
                },
                new Nationality
                {
                    NationalityID = 4,
                    NationalityEN = "Yemeni",
                    NationalityARMale = "يمني",
                    NationalityARFemale = "يمنية"
                },
                new Nationality
                {
                    NationalityID = 5,
                    NationalityEN = "Sudanese",
                    NationalityARMale = "سوداني",
                    NationalityARFemale = "سودانية"
                },
                new Nationality
                {
                    NationalityID = 6,
                    NationalityEN = "Nigerian",
                    NationalityARMale = "نيجيرى",
                    NationalityARFemale = "نيجيرية"
                },
                new Nationality
                {
                    NationalityID = 7,
                    NationalityEN = "Lebanese",
                    NationalityARMale = "لبناني",
                    NationalityARFemale = "لبنانية"
                },
                new Nationality
                {
                    NationalityID = 8,
                    NationalityEN = "Eritrean",
                    NationalityARMale = "ارترى",
                    NationalityARFemale = "ارترية"
                },
                new Nationality
                {
                    NationalityID = 9,
                    NationalityEN = "Turkish",
                    NationalityARMale = "تركى",
                    NationalityARFemale = "تركية"
                },
                new Nationality
                {
                    NationalityID = 10,
                    NationalityEN = "Jordanian",
                    NationalityARMale = "أردني",
                    NationalityARFemale = "أردنية"
                },
                new Nationality
                {
                    NationalityID = 11,
                    NationalityEN = "Moroccan",
                    NationalityARMale = "مغربي",
                    NationalityARFemale = "مغربية"
                },
                new Nationality
                {
                    NationalityID = 12,
                    NationalityEN = "British",
                    NationalityARMale = "بريطاني",
                    NationalityARFemale = "بريطانية"
                },
                new Nationality
                {
                    NationalityID = 13,
                    NationalityEN = "Syrian",
                    NationalityARMale = "سوري",
                    NationalityARFemale = "سورية"
                },
                new Nationality
                {
                    NationalityID = 14,
                    NationalityEN = "Kenyan",
                    NationalityARMale = "كيني",
                    NationalityARFemale = "كينية"
                },
                new Nationality
                {
                    NationalityID = 15,
                    NationalityEN = "Somali",
                    NationalityARMale = "صومالي",
                    NationalityARFemale = "صومالية"
                },
                new Nationality
                {
                    NationalityID = 16,
                    NationalityEN = "Chadian",
                    NationalityARMale = "تشادى",
                    NationalityARFemale = "تشادية"
                },
                new Nationality
                {
                    NationalityID = 17,
                    NationalityEN = "Afghan",
                    NationalityARMale = "افغاني",
                    NationalityARFemale = "افغانية"
                },
                new Nationality
                {
                    NationalityID = 18,
                    NationalityEN = "Malian",
                    NationalityARMale = "مالى",
                    NationalityARFemale = "مالية"
                },
                new Nationality
                {
                    NationalityID = 19,
                    NationalityEN = "Pakistani",
                    NationalityARMale = "باكستانى",
                    NationalityARFemale = "باكستانية"
                },
                new Nationality
                {
                    NationalityID = 20,
                    NationalityEN = "Indian",
                    NationalityARMale = "هندي",
                    NationalityARFemale = "هندية"
                },
                new Nationality
                {
                    NationalityID = 21,
                    NationalityEN = "American",
                    NationalityARMale = "أمريكي",
                    NationalityARFemale = "أمريكية"
                },
                new Nationality
                {
                    NationalityID = 22,
                    NationalityEN = "Ethiopian",
                    NationalityARMale = "اثيوبي",
                    NationalityARFemale = "اثيوبية"
                },
                new Nationality
                {
                    NationalityID = 23,
                    NationalityEN = "Tunisian",
                    NationalityARMale = "تونسي",
                    NationalityARFemale = "تونسية"
                },
                new Nationality
                {
                    NationalityID = 24,
                    NationalityEN = "Algerian",
                    NationalityARMale = "جزائري",
                    NationalityARFemale = "جزائرية"
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
                    ClassName = "A",
                    GradeID = 1,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 2,
                    ClassName = "A",
                    GradeID = 2,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 3,
                    ClassName = "B",
                    GradeID = 2,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 4,
                    ClassName = "C",
                    GradeID = 2,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 5,
                    ClassName = "D",
                    GradeID = 2,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 6,
                    ClassName = "E",
                    GradeID = 2,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 7,
                    ClassName = "A",
                    GradeID = 3,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 8,
                    ClassName = "B",
                    GradeID = 3,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 9,
                    ClassName = "C",
                    GradeID = 3,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 10,
                    ClassName = "D",
                    GradeID = 3,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 11,
                    ClassName = "E",
                    GradeID = 3,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 12,
                    ClassName = "BA",
                    GradeID = 4,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 13,
                    ClassName = "BB",
                    GradeID = 4,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 14,
                    ClassName = "BC",
                    GradeID = 4,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 15,
                    ClassName = "GA",
                    GradeID = 4,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 16,
                    ClassName = "GB",
                    GradeID = 4,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 17,
                    ClassName = "GC",
                    GradeID = 4,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 18,
                    ClassName = "BA",
                    GradeID = 5,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 19,
                    ClassName = "BB",
                    GradeID = 5,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 20,
                    ClassName = "BC",
                    GradeID = 5,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 21,
                    ClassName = "GA",
                    GradeID = 5,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 22,
                    ClassName = "GB",
                    GradeID = 5,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 23,
                    ClassName = "GC",
                    GradeID = 5,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 24,
                    ClassName = "BA",
                    GradeID = 6,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 25,
                    ClassName = "BB",
                    GradeID = 6,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 26,
                    ClassName = "BC",
                    GradeID = 6,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 27,
                    ClassName = "GA",
                    GradeID = 6,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 28,
                    ClassName = "GB",
                    GradeID = 6,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 29,
                    ClassName = "GC",
                    GradeID = 6,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 30,
                    ClassName = "GA",
                    GradeID = 7,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 31,
                    ClassName = "GB",
                    GradeID = 7,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 32,
                    ClassName = "GA",
                    GradeID = 8,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 33,
                    ClassName = "GB",
                    GradeID = 8,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 34,
                    ClassName = "GA",
                    GradeID = 9,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 35,
                    ClassName = "GB",
                    GradeID = 9,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 36,
                    ClassName = "GA",
                    GradeID = 10,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 37,
                    ClassName = "GB",
                    GradeID = 10,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 38,
                    ClassName = "GA",
                    GradeID = 11,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 39,
                    ClassName = "GB",
                    GradeID = 11,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 40,
                    ClassName = "GA",
                    GradeID = 12,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 41,
                    ClassName = "GB",
                    GradeID = 12,
                    SectionName = "Girls"
                },
                new GradeClass
                {
                    GradeClassID = 42,
                    ClassName = "BA",
                    GradeID = 7,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 43,
                    ClassName = "BB",
                    GradeID = 7,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 44,
                    ClassName = "BA",
                    GradeID = 8,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 45,
                    ClassName = "BB",
                    GradeID = 8,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 46,
                    ClassName = "BA",
                    GradeID = 9,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 47,
                    ClassName = "BB",
                    GradeID = 9,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 48,
                    ClassName = "BA",
                    GradeID = 10,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 49,
                    ClassName = "BB",
                    GradeID = 10,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 50,
                    ClassName = "BA",
                    GradeID = 11,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 51,
                    ClassName = "BB",
                    GradeID = 11,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 52,
                    ClassName = "BA",
                    GradeID = 12,
                    SectionName = "Boys"
                },
                new GradeClass
                {
                    GradeClassID = 53,
                    ClassName = "BB",
                    GradeID = 12,
                    SectionName = "Boys"
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
                    CertificateNameAR = "روضة أول",
                    CertificateNameEN = "Kindergarten First Grade",
                    GradeLevel = -1
                },
                new Grade
                {
                    GradeID = 2,
                    GradeName = "KG 2",
                    CertificateNameAR = "روضة ثاني",
                    CertificateNameEN = "Kindergarten Seconde Grade",
                    GradeLevel = -2
                },
                new Grade
                {
                    GradeID = 3,
                    GradeName = "KG 3",
                    CertificateNameAR = "روضة ثالث",
                    CertificateNameEN = "Kindergarten Third Grade",
                    GradeLevel = -3
                },
                new Grade
                {
                    GradeID = 4,
                    GradeName = "Grade 1",
                    CertificateNameAR = "الصف الأول الابتدائى",
                    CertificateNameEN = "Elementary First Grade",
                    GradeLevel = 1
                },
                new Grade
                {
                    GradeID = 5,
                    GradeName = "Grade 2",
                    CertificateNameAR = "الصف الثانى الابتدائى",
                    CertificateNameEN = "Elementary Seconde Grade",
                    GradeLevel = 2
                },
                new Grade
                {
                    GradeID = 6,
                    GradeName = "Grade 3",
                    CertificateNameAR = "الصف الثالث الابتدائى",
                    CertificateNameEN = "Elementary Third Grade",
                    GradeLevel = 3
                },
                new Grade
                {
                    GradeID = 7,
                    GradeName = "Grade 4",
                    CertificateNameAR = "الصف الرابع الابتدائى",
                    CertificateNameEN = "Elementary Fourth Grade",
                    GradeLevel = 4
                },
                new Grade
                {
                    GradeID = 8,
                    GradeName = "Grade 5",
                    CertificateNameAR = "الصف الخامس الابتدائى",
                    CertificateNameEN = "Elementary Fifth Grade",
                    GradeLevel = 5
                },
                new Grade
                {
                    GradeID = 9,
                    GradeName = "Grade 6",
                    CertificateNameAR = "الصف السادس الابتدائى",
                    CertificateNameEN = "Elementary Sixth Grade",
                    GradeLevel = 6
                },
                new Grade
                {
                    GradeID = 10,
                    GradeName = "Grade 7",
                    CertificateNameAR = "الصف الأول المتوسط",
                    CertificateNameEN = "Intermediate First Grade",
                    GradeLevel = 7
                },
                new Grade
                {
                    GradeID = 11,
                    GradeName = "Grade 8",
                    CertificateNameAR = "الصف الثانى المتوسط",
                    CertificateNameEN = "Intermediate Second Grade",
                    GradeLevel = 8
                },
                new Grade
                {
                    GradeID = 12,
                    GradeName = "Grade 9",
                    CertificateNameAR = "الصف الثالث المتوسط",
                    CertificateNameEN = "Intermediate Third Grade",
                    GradeLevel = 9
                }
            );
            modelBuilder.Entity<Year>().HasData(
                new Year
                {
                    YearID=1,
                     YearEN="2024-2025",
                    YearAR="1445-1446" ,
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
            //modelBuilder.Entity<Student>().HasData(
            //        new Student
            //        {
            //            StudentID = "1",
            //            StudentNameEN = "Moaz",
            //            StudentNameAR = "معاذ",
            //            NationalityID = 1,
            //            IDNumber = "12",
            //            IDEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
            //            Passport = "A12",
            //            PassportEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
            //            AdmissionDate = DateOnly.FromDateTime(DateTime.UtcNow),
            //            PreviousSchoolID = 1,
            //            BirthDate = DateOnly.FromDateTime(DateTime.UtcNow),
            //            CurrentClassID = 1,
            //            StudentActiveFlag = 0,
            //            Gender = "Male",
            //            ParentPhone1 = "111",
            //            ParentPhones2 = "222",
            //            StudentPhone = "333",
            //            BirthPlaceID = 1,
            //            DateCreated = DateTime.Now,
            //            CreatedBy = "moaz",
            //            BusID=1,
            //            BusSubscription="ذهاب"

            //        }
            //    );


        }

    }
}
