﻿using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace ProLab.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "Couriers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Couriers", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Users", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Warehouses",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Address_Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Address_City = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                Address_District = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                Address_Parish = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                Address_PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                Address_Location = table.Column<Point>(type: "geography", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Warehouses", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "Routes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CourierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Routes", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Routes_Couriers_CourierId",
                    column: x => x.CourierId,
                    principalTable: "Couriers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Address_Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Address_City = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                Address_District = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                Address_Parish = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                Address_PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                Address_Location = table.Column<Point>(type: "geography", nullable: false),
                WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Orders", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Orders_Warehouses_WarehouseId",
                    column: x => x.WarehouseId,
                    principalTable: "Warehouses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "RouteSection",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                LastOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                IntermediatePoints = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_RouteSection", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_RouteSection_Orders_FirstOrderId",
                    column: x => x.FirstOrderId,
                    principalTable: "Orders",
                    principalColumn: "Id");
                _ = table.ForeignKey(
                    name: "FK_RouteSection_Orders_LastOrderId",
                    column: x => x.LastOrderId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_RouteSection_Routes_RouteId",
                    column: x => x.RouteId,
                    principalTable: "Routes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "IX_Orders_WarehouseId",
            table: "Orders",
            column: "WarehouseId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Routes_CourierId",
            table: "Routes",
            column: "CourierId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RouteSection_FirstOrderId",
            table: "RouteSection",
            column: "FirstOrderId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RouteSection_LastOrderId",
            table: "RouteSection",
            column: "LastOrderId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RouteSection_RouteId",
            table: "RouteSection",
            column: "RouteId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "RouteSection");

        _ = migrationBuilder.DropTable(
            name: "Users");

        _ = migrationBuilder.DropTable(
            name: "Orders");

        _ = migrationBuilder.DropTable(
            name: "Routes");

        _ = migrationBuilder.DropTable(
            name: "Warehouses");

        _ = migrationBuilder.DropTable(
            name: "Couriers");
    }
}
