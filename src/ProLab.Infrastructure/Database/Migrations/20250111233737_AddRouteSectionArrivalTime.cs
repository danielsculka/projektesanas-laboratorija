using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLab.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddRouteSectionArrivalTime : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<TimeOnly>(
            name: "ArrivalTime",
            table: "RouteSections",
            type: "time",
            nullable: false,
            defaultValue: new TimeOnly(0, 0, 0));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "ArrivalTime",
            table: "RouteSections");
    }
}
