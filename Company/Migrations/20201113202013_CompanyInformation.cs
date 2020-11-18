using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Migrations
{
    public partial class CompanyInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    InformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    License = table.Column<string>(nullable: true),
                    Established = table.Column<DateTime>(nullable: false),
                    Revenue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.InformationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Information");
        }
    }
}
