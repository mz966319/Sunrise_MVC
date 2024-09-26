using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SunriseWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudentTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "AdmissionDate", "BirthDate", "BirthPlaceAR", "BirthPlaceEN", "CreatedBy", "CurrentClass", "CurrentGradeID", "DateCreated", "DateUpdated", "Gender", "IDNumber", "IDNumberEndDate", "NationalityEN", "NaturalityAR", "Passport", "PasswordEndDate", "PhoneNumber1", "PhoneNumber2", "PreviousSchoolAR", "PreviousSchoolEN", "StudentNameAR", "StudentNameEN", "StudentStatusFlag", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, "2024-1-1", "", "", "مصر", "", "BA", "4", "", "", "Male", "12", "2022", "Egypt", "مصر", "A12", "2023", "", "", "مدارس", "", "معاذ", "Moaz", 0, "" },
                    { 5, "", "", "كندا", "", "", "BA", "6", "", "", "", "22", "2028", "Canada", "كندا", "A22", "2099", "", "", "شروق", "", "موزة", "Moza", 0, "" },
                    { 6, "", "", "السعودية", "", "", "GB", "5", "", "", "Female", "123", "2025-1-1", "Saudi", "السعودية", "G12", "", "", "", "الشمس", "", "زوز", "Zoz", 0, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "AdmissionDate", "BirthDate", "BirthPlaceAR", "BirthPlaceEN", "CreatedBy", "CurrentClass", "CurrentGradeID", "DateCreated", "DateUpdated", "Gender", "IDNumber", "IDNumberEndDate", "NationalityEN", "NaturalityAR", "Passport", "PasswordEndDate", "PhoneNumber1", "PhoneNumber2", "PreviousSchoolAR", "PreviousSchoolEN", "StudentNameAR", "StudentNameEN", "StudentStatusFlag", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "" },
                    { 2, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "" },
                    { 3, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "" }
                });
        }
    }
}
