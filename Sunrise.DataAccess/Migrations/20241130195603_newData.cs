using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sunrise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    userType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Busses",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusNumber = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busses", x => x.BusID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityARMale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityARFemale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityID);
                });

            migrationBuilder.CreateTable(
                name: "PreviousSchools",
                columns: table => new
                {
                    PreviousSchoolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousSchoolNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousSchoolNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousSchools", x => x.PreviousSchoolID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoorID = table.Column<int>(type: "int", nullable: false),
                    StaticFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    YearID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddmissionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradeClasses",
                columns: table => new
                {
                    GradeClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeClasses", x => x.GradeClassID);
                    table.ForeignKey(
                        name: "FK_GradeClasses_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearManagers",
                columns: table => new
                {
                    YearManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolManagerEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolManagerAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlManagerEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlManagerAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeID = table.Column<int>(type: "int", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearManagers", x => x.YearManagerID);
                    table.ForeignKey(
                        name: "FK_YearManagers_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YearManagers_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearSemesters",
                columns: table => new
                {
                    YearSemesterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterNumber = table.Column<int>(type: "int", nullable: false),
                    SemesterNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SemesterNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizCount = table.Column<int>(type: "int", nullable: false),
                    FinalMark = table.Column<int>(type: "int", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearSemesters", x => x.YearSemesterID);
                    table.ForeignKey(
                        name: "FK_YearSemesters_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AdmissionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentActiveFlag = table.Column<int>(type: "int", nullable: false),
                    AuditorFlag = table.Column<bool>(type: "bit", nullable: false),
                    ParentPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentPhones2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatexStudentID = table.Column<int>(type: "int", nullable: true),
                    MatexParentID = table.Column<int>(type: "int", nullable: true),
                    BusFlag = table.Column<bool>(type: "bit", nullable: false),
                    TmpFlag = table.Column<bool>(type: "bit", nullable: false),
                    BlockFlag = table.Column<bool>(type: "bit", nullable: false),
                    BusSubscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityID = table.Column<int>(type: "int", nullable: true),
                    BirthPlaceID = table.Column<int>(type: "int", nullable: true),
                    PreviousSchoolID = table.Column<int>(type: "int", nullable: true),
                    CurrentClassID = table.Column<int>(type: "int", nullable: false),
                    TemporaryClassID = table.Column<int>(type: "int", nullable: true),
                    BusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Busses_BusID",
                        column: x => x.BusID,
                        principalTable: "Busses",
                        principalColumn: "BusID");
                    table.ForeignKey(
                        name: "FK_Students_Countries_BirthPlaceID",
                        column: x => x.BirthPlaceID,
                        principalTable: "Countries",
                        principalColumn: "CountryID");
                    table.ForeignKey(
                        name: "FK_Students_GradeClasses_CurrentClassID",
                        column: x => x.CurrentClassID,
                        principalTable: "GradeClasses",
                        principalColumn: "GradeClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_GradeClasses_TemporaryClassID",
                        column: x => x.TemporaryClassID,
                        principalTable: "GradeClasses",
                        principalColumn: "GradeClassID");
                    table.ForeignKey(
                        name: "FK_Students_Nationalities_NationalityID",
                        column: x => x.NationalityID,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityID");
                    table.ForeignKey(
                        name: "FK_Students_PreviousSchools_PreviousSchoolID",
                        column: x => x.PreviousSchoolID,
                        principalTable: "PreviousSchools",
                        principalColumn: "PreviousSchoolID");
                });

            migrationBuilder.CreateTable(
                name: "TeacherPermissions",
                columns: table => new
                {
                    TeacherPermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    AcitveFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPermissions", x => x.TeacherPermissionID);
                    table.ForeignKey(
                        name: "FK_TeacherPermissions_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherPermissions_GradeClasses_ClassID",
                        column: x => x.ClassID,
                        principalTable: "GradeClasses",
                        principalColumn: "GradeClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherPermissions_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentControls",
                columns: table => new
                {
                    CurrentControlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearSemesterID = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    Quiz1 = table.Column<int>(type: "int", nullable: false),
                    Quiz2 = table.Column<int>(type: "int", nullable: true),
                    Quiz3 = table.Column<int>(type: "int", nullable: true),
                    ClassWork = table.Column<int>(type: "int", nullable: false),
                    HomeWork = table.Column<int>(type: "int", nullable: false),
                    Behaviour = table.Column<int>(type: "int", nullable: true),
                    Project = table.Column<int>(type: "int", nullable: false),
                    Practical = table.Column<int>(type: "int", nullable: true),
                    ExamMark = table.Column<int>(type: "int", nullable: false),
                    Absent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentControls", x => x.CurrentControlID);
                    table.ForeignKey(
                        name: "FK_CurrentControls_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentControls_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentControls_YearSemesters_YearSemesterID",
                        column: x => x.YearSemesterID,
                        principalTable: "YearSemesters",
                        principalColumn: "YearSemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Busses",
                columns: new[] { "BusID", "BusNumber", "BusPath", "BusPlate", "BusType", "DriverName", "DriverPhone" },
                values: new object[] { 1, 1, "Shemesi", "ABC", "Hilox", "Mo", "0500" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryNameAR", "CountryNameEN" },
                values: new object[,]
                {
                    { 1, "مصر", "Egypt" },
                    { 2, "السعودية", "Saudi Arabia" },
                    { 3, "فلسطين", "Palestine" },
                    { 4, "اليمن", "Yemen" },
                    { 5, "السودان", "Sudan" },
                    { 6, "نيجيريا", "Nigeria" },
                    { 7, "لبنان", "Lebanon" },
                    { 8, "إرتريا", "Eritrea" },
                    { 9, "تركيا", "Turkey" },
                    { 10, "الأردن", "Jordan" },
                    { 11, "المغرب", "Morocco" },
                    { 12, "بريطانيا", "United Kingdom" },
                    { 13, "سوريا", "Syria" },
                    { 14, "كينيا", "Kenya" },
                    { 15, "الصومال", "Somalia" },
                    { 16, "تشاد", "Chad" },
                    { 17, "أفغانستان", "Afghanistan" },
                    { 18, "مالي", "Mali" },
                    { 19, "باكستان", "Pakistan" },
                    { 20, "الهند", "India" },
                    { 21, "الولايات المتحدة الأمريكية", "United States of America" },
                    { 22, "إثيوبيا", "Ethiopia" },
                    { 23, "تونس", "Tunisia" },
                    { 24, "الجزائر", "Algeria" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "CertificateNameAR", "CertificateNameEN", "GradeLevel", "GradeName" },
                values: new object[,]
                {
                    { 1, "روضة أول", "Kindergarten First Grade", -1, "KG 1" },
                    { 2, "روضة ثاني", "Kindergarten Seconde Grade", -2, "KG 2" },
                    { 3, "روضة ثالث", "Kindergarten Third Grade", -3, "KG 3" },
                    { 4, "الصف الأول الابتدائى", "Elementary First Grade", 1, "Grade 1" },
                    { 5, "الصف الثانى الابتدائى", "Elementary Seconde Grade", 2, "Grade 2" },
                    { 6, "الصف الثالث الابتدائى", "Elementary Third Grade", 3, "Grade 3" },
                    { 7, "الصف الرابع الابتدائى", "Elementary Fourth Grade", 4, "Grade 4" },
                    { 8, "الصف الخامس الابتدائى", "Elementary Fifth Grade", 5, "Grade 5" },
                    { 9, "الصف السادس الابتدائى", "Elementary Sixth Grade", 6, "Grade 6" },
                    { 10, "الصف الأول المتوسط", "Intermediate First Grade", 7, "Grade 7" },
                    { 11, "الصف الثانى المتوسط", "Intermediate Second Grade", 8, "Grade 8" },
                    { 12, "الصف الثالث المتوسط", "Intermediate Third Grade", 9, "Grade 9" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityID", "NationalityARFemale", "NationalityARMale", "NationalityEN" },
                values: new object[,]
                {
                    { 1, "مصرية", "مصري", "Egyptian" },
                    { 2, "سعودية", "سعودي", "Saudi" },
                    { 3, "فلسطينية", "فلسطيني", "Palestinian" },
                    { 4, "يمنية", "يمني", "Yemeni" },
                    { 5, "سودانية", "سوداني", "Sudanese" },
                    { 6, "نيجيرية", "نيجيرى", "Nigerian" },
                    { 7, "لبنانية", "لبناني", "Lebanese" },
                    { 8, "ارترية", "ارترى", "Eritrean" },
                    { 9, "تركية", "تركى", "Turkish" },
                    { 10, "أردنية", "أردني", "Jordanian" },
                    { 11, "مغربية", "مغربي", "Moroccan" },
                    { 12, "بريطانية", "بريطاني", "British" },
                    { 13, "سورية", "سوري", "Syrian" },
                    { 14, "كينية", "كيني", "Kenyan" },
                    { 15, "صومالية", "صومالي", "Somali" },
                    { 16, "تشادية", "تشادى", "Chadian" },
                    { 17, "افغانية", "افغاني", "Afghan" },
                    { 18, "مالية", "مالى", "Malian" },
                    { 19, "باكستانية", "باكستانى", "Pakistani" },
                    { 20, "هندية", "هندي", "Indian" },
                    { 21, "أمريكية", "أمريكي", "American" },
                    { 22, "اثيوبية", "اثيوبي", "Ethiopian" },
                    { 23, "تونسية", "تونسي", "Tunisian" },
                    { 24, "جزائرية", "جزائري", "Algerian" }
                });

            migrationBuilder.InsertData(
                table: "PreviousSchools",
                columns: new[] { "PreviousSchoolID", "PreviousSchoolNameAR", "PreviousSchoolNameEN" },
                values: new object[] { 1, "مدارس شروق الشمس العالمية", "Sunrise International Schools" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectID", "NoorID", "NoorName", "StaticFlag", "SubjectNameAR", "SubjectNameEN" },
                values: new object[,]
                {
                    { 1, 291, "القرآن الكريم والدراسات الإسلامية", false, "الدراسات الإسلامية", "Islamic St." },
                    { 2, 157, "اللغة العربية", false, "اللغة العربية", "Arabic" },
                    { 3, 289, "الإجتماعيات", false, "الإجتماعيات", "Social Studies" },
                    { 4, 14, "اللغة الإنجليزية", false, "اللغة الإنجليزية", "English" },
                    { 5, 200548, "اللغة الفرنسية", false, "اللغة الفرنسية", "French" },
                    { 6, 74, "العلوم", false, "العلوم", "Science" },
                    { 11, 16, "الرياضيات", false, "الرياضيات", "Mathematics" },
                    { 12, 201110, "اجتماعيات باللغة الانجليزية", false, "الاجتماعيات (بالانجليزي)", "Social Studies (Eng)" },
                    { 14, 46, "الحاسب الآلي", false, "الحاسب الآلي", "Computer" },
                    { 15, 30, "التربية البدنية", true, "التربية البدنية", "Physical Education" },
                    { 16, 0, "السلوك", true, "السلوك", "Conduct" },
                    { 17, 0, "المواظبة", true, "المواظبة", "Attendance" }
                });

            migrationBuilder.InsertData(
                table: "Years",
                columns: new[] { "YearID", "ActiveFlag", "AddmissionDate", "YearAR", "YearEN" },
                values: new object[] { 1, true, new DateOnly(2024, 11, 30), "1445-1446", "2024-2025" });

            migrationBuilder.InsertData(
                table: "GradeClasses",
                columns: new[] { "GradeClassID", "ClassName", "GradeID", "SectionName" },
                values: new object[,]
                {
                    { 1, "A", 1, "Girls" },
                    { 2, "A", 2, "Girls" },
                    { 3, "B", 2, "Girls" },
                    { 4, "C", 2, "Girls" },
                    { 5, "D", 2, "Girls" },
                    { 6, "E", 2, "Girls" },
                    { 7, "A", 3, "Girls" },
                    { 8, "B", 3, "Girls" },
                    { 9, "C", 3, "Girls" },
                    { 10, "D", 3, "Girls" },
                    { 11, "E", 3, "Girls" },
                    { 12, "BA", 4, "Girls" },
                    { 13, "BB", 4, "Girls" },
                    { 14, "BC", 4, "Girls" },
                    { 15, "GA", 4, "Girls" },
                    { 16, "GB", 4, "Girls" },
                    { 17, "GC", 4, "Girls" },
                    { 18, "BA", 5, "Girls" },
                    { 19, "BB", 5, "Girls" },
                    { 20, "BC", 5, "Girls" },
                    { 21, "GA", 5, "Girls" },
                    { 22, "GB", 5, "Girls" },
                    { 23, "GC", 5, "Girls" },
                    { 24, "BA", 6, "Girls" },
                    { 25, "BB", 6, "Girls" },
                    { 26, "BC", 6, "Girls" },
                    { 27, "GA", 6, "Girls" },
                    { 28, "GB", 6, "Girls" },
                    { 29, "GC", 6, "Girls" },
                    { 30, "GA", 7, "Girls" },
                    { 31, "GB", 7, "Girls" },
                    { 32, "GA", 8, "Girls" },
                    { 33, "GB", 8, "Girls" },
                    { 34, "GA", 9, "Girls" },
                    { 35, "GB", 9, "Girls" },
                    { 36, "GA", 10, "Girls" },
                    { 37, "GB", 10, "Girls" },
                    { 38, "GA", 11, "Girls" },
                    { 39, "GB", 11, "Girls" },
                    { 40, "GA", 12, "Girls" },
                    { 41, "GB", 12, "Girls" },
                    { 42, "BA", 7, "Boys" },
                    { 43, "BB", 7, "Boys" },
                    { 44, "BA", 8, "Boys" },
                    { 45, "BB", 8, "Boys" },
                    { 46, "BA", 9, "Boys" },
                    { 47, "BB", 9, "Boys" },
                    { 48, "BA", 10, "Boys" },
                    { 49, "BB", 10, "Boys" },
                    { 50, "BA", 11, "Boys" },
                    { 51, "BB", 11, "Boys" },
                    { 52, "BA", 12, "Boys" },
                    { 53, "BB", 12, "Boys" }
                });

            migrationBuilder.InsertData(
                table: "YearManagers",
                columns: new[] { "YearManagerID", "ControlManagerAR", "ControlManagerEN", "GradeID", "SchoolManagerAR", "SchoolManagerEN", "YearID" },
                values: new object[] { 1, "اذ", "az", 1, "مع", "mo", 1 });

            migrationBuilder.InsertData(
                table: "YearSemesters",
                columns: new[] { "YearSemesterID", "ActiveFlag", "FinalMark", "QuizCount", "SemesterNameAR", "SemesterNameEN", "SemesterNumber", "YearID" },
                values: new object[] { 1, true, 25, 2, "الفصل الدراسي الأول", "First Semester", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentControls_StudentID",
                table: "CurrentControls",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentControls_SubjectID",
                table: "CurrentControls",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentControls_YearSemesterID",
                table: "CurrentControls",
                column: "YearSemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeClasses_GradeID",
                table: "GradeClasses",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BirthPlaceID",
                table: "Students",
                column: "BirthPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BusID",
                table: "Students",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentClassID",
                table: "Students",
                column: "CurrentClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationalityID",
                table: "Students",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PreviousSchoolID",
                table: "Students",
                column: "PreviousSchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TemporaryClassID",
                table: "Students",
                column: "TemporaryClassID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPermissions_ClassID",
                table: "TeacherPermissions",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPermissions_SubjectID",
                table: "TeacherPermissions",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPermissions_UserID",
                table: "TeacherPermissions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_YearManagers_GradeID",
                table: "YearManagers",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_YearManagers_YearID",
                table: "YearManagers",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_YearSemesters_YearID",
                table: "YearSemesters",
                column: "YearID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CurrentControls");

            migrationBuilder.DropTable(
                name: "TeacherPermissions");

            migrationBuilder.DropTable(
                name: "YearManagers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "YearSemesters");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Busses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "GradeClasses");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "PreviousSchools");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
