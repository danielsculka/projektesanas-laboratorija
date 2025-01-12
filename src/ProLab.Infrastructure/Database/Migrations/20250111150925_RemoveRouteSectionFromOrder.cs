using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLab.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRouteSectionFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_RouteSections_Orders_FromOrderId",
                table: "RouteSections");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_RouteSections_Orders_ToOrderId",
                table: "RouteSections");

            _ = migrationBuilder.DropIndex(
                name: "IX_RouteSections_FromOrderId",
                table: "RouteSections");

            _ = migrationBuilder.DropColumn(
                name: "FromOrderId",
                table: "RouteSections");

            _ = migrationBuilder.RenameColumn(
                name: "ToOrderId",
                table: "RouteSections",
                newName: "OrderId");

            _ = migrationBuilder.RenameIndex(
                name: "IX_RouteSections_ToOrderId",
                table: "RouteSections",
                newName: "IX_RouteSections_OrderId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_RouteSections_Orders_OrderId",
                table: "RouteSections",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_RouteSections_Orders_OrderId",
                table: "RouteSections");

            _ = migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "RouteSections",
                newName: "ToOrderId");

            _ = migrationBuilder.RenameIndex(
                name: "IX_RouteSections_OrderId",
                table: "RouteSections",
                newName: "IX_RouteSections_ToOrderId");

            _ = migrationBuilder.AddColumn<int>(
                name: "FromOrderId",
                table: "RouteSections",
                type: "int",
                nullable: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_RouteSections_FromOrderId",
                table: "RouteSections",
                column: "FromOrderId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_RouteSections_Orders_FromOrderId",
                table: "RouteSections",
                column: "FromOrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_RouteSections_Orders_ToOrderId",
                table: "RouteSections",
                column: "ToOrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
