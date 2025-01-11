using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLab.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class ChangeOrderStartAndEndFromDateToTime : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "EndDate",
            table: "Orders");

        _ = migrationBuilder.DropColumn(
            name: "StartDate",
            table: "Orders");

        _ = migrationBuilder.AddColumn<TimeOnly>(
            name: "EndTime",
            table: "Orders",
            type: "time",
            nullable: false,
            defaultValue: new TimeOnly(0, 0, 0));

        _ = migrationBuilder.AddColumn<TimeOnly>(
            name: "StartTime",
            table: "Orders",
            type: "time",
            nullable: false,
            defaultValue: new TimeOnly(0, 0, 0));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "EndTime",
            table: "Orders");

        _ = migrationBuilder.DropColumn(
            name: "StartTime",
            table: "Orders");

        _ = migrationBuilder.AddColumn<DateTime>(
            name: "EndDate",
            table: "Orders",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        _ = migrationBuilder.AddColumn<DateTime>(
            name: "StartDate",
            table: "Orders",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
    }
}
