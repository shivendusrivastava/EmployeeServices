using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeServices.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Empcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Designation", "Doj", "Empcode", "FirstName", "LastName", "LoginName" },
                values: new object[,]
                {
                    { "0e446ba0-476c-4c16-918f-4dd35829a861", "Consultant", "02-Feb-2021", "1121055", "Shivendu", "Srivastava", "shiv.sri" },
                    { "b672dd42-b73f-4886-b499-fc7bff6f44d4", "Sr. Business Analyst", "08-Jun-2020", "1135109", "Kinjalk", "Tripathi", "kinj.tri" },
                    { "bbd718d8-b9b3-4f6c-adca-09b13327d920", "Sr. Security Specialist", "14-Apr-2019", "1156820", "Akrati", "Bajpai", "akra.baj" },
                    { "55b7e9d5-eaaa-4386-a5c4-259de5fd89b5", "Sr. Finance Advisor", "11-May-2015", "1135820", "Raghav", "Gowda", "ragh.gow" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
