using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLab.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddDateForOrdersAndRouteSets : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<DateOnly>(
            name: "Date",
            table: "RouteSets",
            type: "date",
            nullable: false,
            defaultValue: new DateOnly(1, 1, 1));

        _ = migrationBuilder.AddColumn<TimeOnly>(
            name: "EndTime",
            table: "RouteSets",
            type: "time",
            nullable: false,
            defaultValue: new TimeOnly(0, 0, 0));

        _ = migrationBuilder.AddColumn<TimeOnly>(
            name: "StartTime",
            table: "RouteSets",
            type: "time",
            nullable: false,
            defaultValue: new TimeOnly(0, 0, 0));

        _ = migrationBuilder.AddColumn<DateOnly>(
            name: "Date",
            table: "Orders",
            type: "date",
            nullable: false,
            defaultValue: new DateOnly(1, 1, 1));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "Date",
            table: "RouteSets");

        _ = migrationBuilder.DropColumn(
            name: "EndTime",
            table: "RouteSets");

        _ = migrationBuilder.DropColumn(
            name: "StartTime",
            table: "RouteSets");

        _ = migrationBuilder.DropColumn(
            name: "Date",
            table: "Orders");
    }
}
