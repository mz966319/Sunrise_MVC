using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunrise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teacherPermissions",
                columns: table => new
                {
                    TeacherPermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    AcitveFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherPermissions", x => x.TeacherPermissionID);
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 20, 21, 49, 58, 483, DateTimeKind.Local).AddTicks(4785));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teacherPermissions");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 20, 8, 42, 2, 1, DateTimeKind.Local).AddTicks(9789));
        }
    }
}
