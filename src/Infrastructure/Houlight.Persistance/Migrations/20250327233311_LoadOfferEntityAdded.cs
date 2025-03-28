using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Houlight.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LoadOfferEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoadOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerExpectedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CompanyOfferedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogisticsCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadOffers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoadOffers_Drivers_AssignedDriverId",
                        column: x => x.AssignedDriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoadOffers_Loads_LoadId",
                        column: x => x.LoadId,
                        principalTable: "Loads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoadOffers_LogisticsCompanies_LogisticsCompanyId",
                        column: x => x.LogisticsCompanyId,
                        principalTable: "LogisticsCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoadOffers_Vehicles_AssignedVehicleId",
                        column: x => x.AssignedVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoadOffers_AssignedDriverId",
                table: "LoadOffers",
                column: "AssignedDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadOffers_AssignedVehicleId",
                table: "LoadOffers",
                column: "AssignedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadOffers_CustomerId",
                table: "LoadOffers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadOffers_LoadId",
                table: "LoadOffers",
                column: "LoadId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadOffers_LogisticsCompanyId",
                table: "LoadOffers",
                column: "LogisticsCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadOffers");
        }
    }
}
