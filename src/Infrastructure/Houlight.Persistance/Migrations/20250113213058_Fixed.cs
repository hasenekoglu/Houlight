using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Houlight.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyEntityId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyEntityId1",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_LogisticsCompanies_LogisticsCompanyEntityId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_LogisticsCompanies_LogisticsCompanyEntityId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_LogisticsCompanyEntityId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_LogisticsCompanyEntityId1",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LogisticsCompanyEntityId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LogisticsCompanyEntityId1",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "LogisticsCompanyEntityId",
                table: "Vehicles",
                newName: "LogisticsCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_LogisticsCompanyEntityId",
                table: "Vehicles",
                newName: "IX_Vehicles_LogisticsCompanyId");

            migrationBuilder.RenameColumn(
                name: "LogisticsCompanyEntityId",
                table: "Drivers",
                newName: "LogisticsCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_LogisticsCompanyEntityId",
                table: "Drivers",
                newName: "IX_Drivers_LogisticsCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyId",
                table: "Drivers",
                column: "LogisticsCompanyId",
                principalTable: "LogisticsCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_LogisticsCompanies_LogisticsCompanyId",
                table: "Vehicles",
                column: "LogisticsCompanyId",
                principalTable: "LogisticsCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_LogisticsCompanies_LogisticsCompanyId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "LogisticsCompanyId",
                table: "Vehicles",
                newName: "LogisticsCompanyEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_LogisticsCompanyId",
                table: "Vehicles",
                newName: "IX_Vehicles_LogisticsCompanyEntityId");

            migrationBuilder.RenameColumn(
                name: "LogisticsCompanyId",
                table: "Drivers",
                newName: "LogisticsCompanyEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_LogisticsCompanyId",
                table: "Drivers",
                newName: "IX_Drivers_LogisticsCompanyEntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "LogisticsCompanyEntityId1",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LogisticsCompanyEntityId1",
                table: "Drivers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LogisticsCompanyEntityId1",
                table: "Vehicles",
                column: "LogisticsCompanyEntityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LogisticsCompanyEntityId1",
                table: "Drivers",
                column: "LogisticsCompanyEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyEntityId",
                table: "Drivers",
                column: "LogisticsCompanyEntityId",
                principalTable: "LogisticsCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyEntityId1",
                table: "Drivers",
                column: "LogisticsCompanyEntityId1",
                principalTable: "LogisticsCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_LogisticsCompanies_LogisticsCompanyEntityId",
                table: "Vehicles",
                column: "LogisticsCompanyEntityId",
                principalTable: "LogisticsCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_LogisticsCompanies_LogisticsCompanyEntityId1",
                table: "Vehicles",
                column: "LogisticsCompanyEntityId1",
                principalTable: "LogisticsCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
