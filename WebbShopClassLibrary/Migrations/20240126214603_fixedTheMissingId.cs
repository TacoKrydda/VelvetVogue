using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbShopClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class fixedTheMissingId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Staff",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CartItemId",
                table: "CartItems",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Staff",
                newName: "StaffId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CartItems",
                newName: "CartItemId");
        }
    }
}
