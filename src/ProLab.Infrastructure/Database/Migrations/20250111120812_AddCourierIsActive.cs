using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProLab.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddCourierIsActive : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<bool>(
            name: "IsActive",
            table: "Couriers",
            type: "bit",
            nullable: false,
            defaultValue: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "IsActive",
            table: "Couriers");
    }
}
