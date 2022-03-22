using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomersWebapp.CustomersDbContextMigration
{
    public partial class InitaialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Department", "Email", "ManagerId", "Name", "Phone" },
                values: new object[] { 1, "Department", "elkadim@email.com", 0, "Wael Elkadim", "01324213" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Department", "Email", "ManagerId", "Name", "Phone" },
                values: new object[] { 2, "Department", "amohamed@email.com", 0, "Ahmed Mohamed", "01322213" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Department", "Email", "ManagerId", "Name", "Phone" },
                values: new object[] { 3, "Department", "alimohamed@email.com", 0, "Ali Mohamed", "01324223" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
