using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbShopClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeperateOrderAndStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderStaffAssignments",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStaffAssignments", x => new { x.OrderId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_OrderStaffAssignments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStaffAssignments_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderStaffAssignments_StaffId",
                table: "OrderStaffAssignments",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStaffAssignments");
        }
    }
}
