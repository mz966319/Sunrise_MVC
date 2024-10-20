using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunrise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _11111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_teacherPermissions",
                table: "teacherPermissions");

            migrationBuilder.RenameTable(
                name: "teacherPermissions",
                newName: "TeacherPermissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherPermissions",
                table: "TeacherPermissions",
                column: "TeacherPermissionID");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 20, 22, 1, 25, 420, DateTimeKind.Local).AddTicks(4007));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherPermissions",
                table: "TeacherPermissions");

            migrationBuilder.RenameTable(
                name: "TeacherPermissions",
                newName: "teacherPermissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teacherPermissions",
                table: "teacherPermissions",
                column: "TeacherPermissionID");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 20, 22, 0, 2, 201, DateTimeKind.Local).AddTicks(9927));
        }
    }
}
