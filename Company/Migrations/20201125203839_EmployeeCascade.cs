using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Migrations
{
    public partial class EmployeeCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department",
                table: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department",
                table: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
