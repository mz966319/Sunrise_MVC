using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunrise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _111111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "TeacherPermissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 20, 22, 18, 15, 878, DateTimeKind.Local).AddTicks(9678));

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

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPermissions_AspNetUsers_UserID",
                table: "TeacherPermissions",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPermissions_GradeClasses_ClassID",
                table: "TeacherPermissions",
                column: "ClassID",
                principalTable: "GradeClasses",
                principalColumn: "GradeClassID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPermissions_Subjects_SubjectID",
                table: "TeacherPermissions",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPermissions_AspNetUsers_UserID",
                table: "TeacherPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPermissions_GradeClasses_ClassID",
                table: "TeacherPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPermissions_Subjects_SubjectID",
                table: "TeacherPermissions");

            migrationBuilder.DropIndex(
                name: "IX_TeacherPermissions_ClassID",
                table: "TeacherPermissions");

            migrationBuilder.DropIndex(
                name: "IX_TeacherPermissions_SubjectID",
                table: "TeacherPermissions");

            migrationBuilder.DropIndex(
                name: "IX_TeacherPermissions_UserID",
                table: "TeacherPermissions");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "TeacherPermissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 10, 20, 22, 1, 25, 420, DateTimeKind.Local).AddTicks(4007));
        }
    }
}
