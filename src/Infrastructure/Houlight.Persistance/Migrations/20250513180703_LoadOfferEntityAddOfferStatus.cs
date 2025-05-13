using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Houlight.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LoadOfferEntityAddOfferStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferStatus",
                table: "LoadOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferStatus",
                table: "LoadOffers");
        }
    }
}
