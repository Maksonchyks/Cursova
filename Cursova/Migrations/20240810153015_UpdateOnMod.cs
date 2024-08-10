using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursova.Migrations
{
    public partial class UpdateOnMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_SalesDeals_Stocks_FrStockId",
                table: "SalesDeals");

            migrationBuilder.DropIndex(
                name: "IX_SalesDeals_FrStockId",
                table: "SalesDeals");

            migrationBuilder.RenameColumn(
                name: "Addresss",
                table: "Suppliers",
                newName: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDeals_FrStockId",
                table: "SalesDeals",
                column: "FrStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDeals_Stocks_FrStockId",
                table: "SalesDeals",
                column: "FrStockId",
                principalTable: "Stocks",
                principalColumn: "StockId",
                onDelete: ReferentialAction.Cascade);

        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDeals_Stocks_FrStockId",
                table: "SalesDeals");

            migrationBuilder.DropIndex(
                name: "IX_SalesDeals_FrStockId",
                table: "SalesDeals");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Suppliers",
                newName: "Addresss");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDeals_FrStockId",
                table: "SalesDeals",
                column: "FrStockId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDeals_Stocks_FrStockId",
                table: "SalesDeals",
                column: "FrStockId",
                principalTable: "Stocks",
                principalColumn: "StockId",
                onDelete: ReferentialAction.Cascade);

        }
    }
}
