using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace ProLab.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddRouteSectionDistanceAndDuration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "IntermediatePoints",
            table: "RouteSections");

        _ = migrationBuilder.AddColumn<double>(
            name: "Distance",
            table: "RouteSections",
            type: "float",
            nullable: false,
            defaultValue: 0.0);

        _ = migrationBuilder.AddColumn<double>(
            name: "Duration",
            table: "RouteSections",
            type: "float",
            nullable: false,
            defaultValue: 0.0);

        _ = migrationBuilder.AddColumn<LineString>(
            name: "Path",
            table: "RouteSections",
            type: "geography",
            nullable: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "Distance",
            table: "RouteSections");

        _ = migrationBuilder.DropColumn(
            name: "Duration",
            table: "RouteSections");

        _ = migrationBuilder.DropColumn(
            name: "Path",
            table: "RouteSections");

        _ = migrationBuilder.AddColumn<string>(
            name: "IntermediatePoints",
            table: "RouteSections",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }
}
