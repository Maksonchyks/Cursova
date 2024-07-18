using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursova.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrederDate",
                table: "SalesDeals",
                newName: "OrderDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "SalesDeals",
                newName: "OrederDate");
        }
    }
}
