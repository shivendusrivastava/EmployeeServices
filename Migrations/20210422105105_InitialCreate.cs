using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeServices.Migrations
{
    public partial class InitialCreate : Migration
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
                    { "52f1e8f9-70cb-40d2-8712-ce1c440c9fa8", "Consultant", "02-Feb-2021", "1121055", "Shivendu", "Srivastava", "shiv.sri" },
                    { "ae717a5b-cda2-410a-9484-a9b7460609c0", "Sr. Business Analyst", "08-Jun-2020", "1135109", "Kinjalk", "Tripathi", "kinj.tri" },
                    { "ac4ace0d-8d2e-4734-ba7f-93880c24d067", "Sr. Security Specialist", "14-Apr-2019", "1156820", "Akrati", "Bajpai", "akra.baj" },
                    { "dec7e46e-8c09-4c01-a7a3-694ed60a91ad", "Sr. Finance Advisor", "11-May-2015", "1135820", "Raghav", "Gowda", "ragh.gow" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
