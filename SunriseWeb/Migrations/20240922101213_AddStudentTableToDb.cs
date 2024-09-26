using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunriseWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalityAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNumberEndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordEndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousSchoolEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousSchoolAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentGradeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentStatusFlag = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthPlaceEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthPlaceAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
