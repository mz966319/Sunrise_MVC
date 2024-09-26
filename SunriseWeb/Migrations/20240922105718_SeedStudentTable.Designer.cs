﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SunriseWeb.Data;

#nullable disable

namespace SunriseWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240922105718_SeedStudentTable")]
    partial class SeedStudentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SunriseWeb.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("AdmissionDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthPlaceAR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthPlaceEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentGradeID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateCreated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateUpdated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDNumberEndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalityEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NaturalityAR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordEndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousSchoolAR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousSchoolEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentNameAR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentNameEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentStatusFlag")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = 1,
                            AdmissionDate = "",
                            BirthDate = "",
                            BirthPlaceAR = "",
                            BirthPlaceEN = "",
                            CreatedBy = "",
                            CurrentClass = "",
                            CurrentGradeID = "",
                            DateCreated = "",
                            DateUpdated = "",
                            Gender = "",
                            IDNumber = "",
                            IDNumberEndDate = "",
                            NationalityEN = "",
                            NaturalityAR = "",
                            Passport = "",
                            PasswordEndDate = "",
                            PhoneNumber1 = "",
                            PhoneNumber2 = "",
                            PreviousSchoolAR = "",
                            PreviousSchoolEN = "",
                            StudentNameAR = "",
                            StudentNameEN = "",
                            StudentStatusFlag = 0,
                            UpdatedBy = ""
                        },
                        new
                        {
                            StudentID = 2,
                            AdmissionDate = "",
                            BirthDate = "",
                            BirthPlaceAR = "",
                            BirthPlaceEN = "",
                            CreatedBy = "",
                            CurrentClass = "",
                            CurrentGradeID = "",
                            DateCreated = "",
                            DateUpdated = "",
                            Gender = "",
                            IDNumber = "",
                            IDNumberEndDate = "",
                            NationalityEN = "",
                            NaturalityAR = "",
                            Passport = "",
                            PasswordEndDate = "",
                            PhoneNumber1 = "",
                            PhoneNumber2 = "",
                            PreviousSchoolAR = "",
                            PreviousSchoolEN = "",
                            StudentNameAR = "",
                            StudentNameEN = "",
                            StudentStatusFlag = 0,
                            UpdatedBy = ""
                        },
                        new
                        {
                            StudentID = 3,
                            AdmissionDate = "",
                            BirthDate = "",
                            BirthPlaceAR = "",
                            BirthPlaceEN = "",
                            CreatedBy = "",
                            CurrentClass = "",
                            CurrentGradeID = "",
                            DateCreated = "",
                            DateUpdated = "",
                            Gender = "",
                            IDNumber = "",
                            IDNumberEndDate = "",
                            NationalityEN = "",
                            NaturalityAR = "",
                            Passport = "",
                            PasswordEndDate = "",
                            PhoneNumber1 = "",
                            PhoneNumber2 = "",
                            PreviousSchoolAR = "",
                            PreviousSchoolEN = "",
                            StudentNameAR = "",
                            StudentNameEN = "",
                            StudentStatusFlag = 0,
                            UpdatedBy = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
