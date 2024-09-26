using Microsoft.EntityFrameworkCore;
using SunriseWeb.Models;

namespace SunriseWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet <Student> Students { get; set; }
        public DbSet <Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                    new Student
                    {
                        StudentID = 4,
                        StudentNameEN = "Moaz",
                        StudentNameAR = "معاذ",
                        NationalityID = 1,
                        IDNumber = "12",
                        IDEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        Passport = "A12",
                        PassportEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        AdmissionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        PreviousSchoolEN = "",
                        PreviousSchoolAR = "مدارس",
                        BirthDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        CurrentClassID = 1,
                        CurrentGradeID = 1,
                        StudentActiveFlag = 0,
                        Gender = "Male",
                        PhoneNumber1 = "",
                        PhoneNumber2 = "",
                        BirthPlaceID= 1,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        CreatedBy = "",
                        UpdatedBy = ""
                    },
                    new Student
                    {
                        StudentID = 5,
                        StudentNameEN = "Moza",
                        StudentNameAR = "موزة",
                        NationalityID = 10,
                        IDNumber = "22",
                        IDEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        Passport = "A22",
                        PassportEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        AdmissionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        PreviousSchoolEN = "",
                        PreviousSchoolAR = "شروق",
                        BirthDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        CurrentClassID = 1,
                        CurrentGradeID = 1,
                        StudentActiveFlag = 0,
                        Gender = "",
                        PhoneNumber1 = "",
                        PhoneNumber2 = "",
                        BirthPlaceID = 10,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        CreatedBy = "",
                        UpdatedBy = ""
                    },
                    new Student
                    {
                        StudentID = 6,
                        StudentNameEN = "Zoz",
                        StudentNameAR = "زوز",
                        NationalityID = 10,
                        IDNumber = "123",
                        IDEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        Passport = "G12",
                        PassportEndDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        AdmissionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        PreviousSchoolEN = "",
                        PreviousSchoolAR = "الشمس",
                        BirthDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        CurrentClassID = 1,
                        CurrentGradeID = 1,
                        StudentActiveFlag = 0,
                        Gender = "Female",
                        PhoneNumber1 = "",
                        PhoneNumber2 = "",
                        BirthPlaceID= 10,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        CreatedBy = "",
                        UpdatedBy = ""
                    }
                );
            modelBuilder.Entity<Country>().HasData(
                    new Country
                    {
                        CountryID = 1,
                        CountryNameEN = "Moaz",
                        CountryNameAR = "معاذ",
                        NationalityEN = "Egypt",
                        NationalityARMale = "مصر",
                        NationalityARFemale = "12"
                    },
                    new Country
                    {
                        CountryID = 2,
                        CountryNameEN = "Moaz2",
                        CountryNameAR = "معاذ2",
                        NationalityEN = "Egypt2",
                        NationalityARMale = "2مصر",
                        NationalityARFemale = "122"
                    },
                    new Country
                    {
                        CountryID = 3,
                        CountryNameEN = "Moaz3",
                        CountryNameAR = "معاذ3",
                        NationalityEN = "Egypt3",
                        NationalityARMale = "3مصر",
                        NationalityARFemale = "123"
                    }
                );
        }
    }
}
