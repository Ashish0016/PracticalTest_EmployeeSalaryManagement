using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpMgmt.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeCode = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 8, nullable: false),
                    Gender = table.Column<bool>(type: "bit", maxLength: 1, nullable: false, defaultValue: false),
                    Department = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BasicSalary = table.Column<float>(type: "real", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
