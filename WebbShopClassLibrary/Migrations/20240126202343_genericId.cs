using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbShopClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class genericId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Stocks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Sizes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Colors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Brands",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stocks",
                newName: "StockId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sizes",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Colors",
                newName: "ColorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "BrandId");
        }
    }
}
