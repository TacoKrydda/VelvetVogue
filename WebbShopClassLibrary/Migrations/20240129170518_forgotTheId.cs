using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbShopClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class forgotTheId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStaffAssignments",
                table: "OrderStaffAssignments");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderStaffAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStaffAssignments",
                table: "OrderStaffAssignments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStaffAssignments_OrderId",
                table: "OrderStaffAssignments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStaffAssignments",
                table: "OrderStaffAssignments");

            migrationBuilder.DropIndex(
                name: "IX_OrderStaffAssignments_OrderId",
                table: "OrderStaffAssignments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderStaffAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStaffAssignments",
                table: "OrderStaffAssignments",
                columns: new[] { "OrderId", "StaffId" });
        }
    }
}
