using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace ProLab.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddAddresses : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "Addresses",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                City = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                District = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                Parish = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                Location = table.Column<Point>(type: "geography", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Addresses", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "Addresses");
    }
}
