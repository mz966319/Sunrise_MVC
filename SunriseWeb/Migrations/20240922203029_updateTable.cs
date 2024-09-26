using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunriseWeb.Migrations
{
    /// <inheritdoc />
    public partial class updateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordEndDate",
                table: "Students",
                newName: "PassportEndDate");

            migrationBuilder.RenameColumn(
                name: "NaturalityAR",
                table: "Students",
                newName: "NationalityAR");

            migrationBuilder.RenameColumn(
                name: "IDNumberEndDate",
                table: "Students",
                newName: "IDEndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassportEndDate",
                table: "Students",
                newName: "PasswordEndDate");

            migrationBuilder.RenameColumn(
                name: "NationalityAR",
                table: "Students",
                newName: "NaturalityAR");

            migrationBuilder.RenameColumn(
                name: "IDEndDate",
                table: "Students",
                newName: "IDNumberEndDate");
        }
    }
}
