using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLab.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddRouteSetGenerateDuration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<TimeSpan>(
            name: "GenerateDuration",
            table: "RouteSets",
            type: "time",
            nullable: false,
            defaultValue: new TimeSpan(0, 0, 0, 0, 0));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "GenerateDuration",
            table: "RouteSets");
    }
}
