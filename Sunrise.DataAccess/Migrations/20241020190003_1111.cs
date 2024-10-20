using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunrise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _1111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "teacherPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 20, 22, 0, 2, 201, DateTimeKind.Local).AddTicks(9927));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "teacherPermissions");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 20, 21, 49, 58, 483, DateTimeKind.Local).AddTicks(4785));
        }
    }
}
