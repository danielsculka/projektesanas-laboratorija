using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLab.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class ChangeRouteSectionFirstToFromAndLastToTo : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_RouteSections_Orders_FirstOrderId",
            table: "RouteSections");

        _ = migrationBuilder.DropForeignKey(
            name: "FK_RouteSections_Orders_LastOrderId",
            table: "RouteSections");

        _ = migrationBuilder.RenameColumn(
            name: "LastOrderId",
            table: "RouteSections",
            newName: "ToOrderId");

        _ = migrationBuilder.RenameColumn(
            name: "FirstOrderId",
            table: "RouteSections",
            newName: "FromOrderId");

        _ = migrationBuilder.RenameIndex(
            name: "IX_RouteSections_LastOrderId",
            table: "RouteSections",
            newName: "IX_RouteSections_ToOrderId");

        _ = migrationBuilder.RenameIndex(
            name: "IX_RouteSections_FirstOrderId",
            table: "RouteSections",
            newName: "IX_RouteSections_FromOrderId");

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

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_RouteSections_Orders_FromOrderId",
            table: "RouteSections");

        _ = migrationBuilder.DropForeignKey(
            name: "FK_RouteSections_Orders_ToOrderId",
            table: "RouteSections");

        _ = migrationBuilder.RenameColumn(
            name: "ToOrderId",
            table: "RouteSections",
            newName: "LastOrderId");

        _ = migrationBuilder.RenameColumn(
            name: "FromOrderId",
            table: "RouteSections",
            newName: "FirstOrderId");

        _ = migrationBuilder.RenameIndex(
            name: "IX_RouteSections_ToOrderId",
            table: "RouteSections",
            newName: "IX_RouteSections_LastOrderId");

        _ = migrationBuilder.RenameIndex(
            name: "IX_RouteSections_FromOrderId",
            table: "RouteSections",
            newName: "IX_RouteSections_FirstOrderId");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_RouteSections_Orders_FirstOrderId",
            table: "RouteSections",
            column: "FirstOrderId",
            principalTable: "Orders",
            principalColumn: "Id");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_RouteSections_Orders_LastOrderId",
            table: "RouteSections",
            column: "LastOrderId",
            principalTable: "Orders",
            principalColumn: "Id");
    }
}
