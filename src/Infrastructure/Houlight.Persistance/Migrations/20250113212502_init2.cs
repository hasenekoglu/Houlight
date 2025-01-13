using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Houlight.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_LogisticsCompanies_LogisticsCompanyId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_LogisticsCompanyId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_LogisticsCompanyId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LogisticsCompanyId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LogisticsCompanyId",
                table: "Drivers");

            migrationBuilder.AlterColumn<Guid>(
                name: "LogisticsCompanyEntityId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LogisticsCompanyEntityId1",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LogisticsCompanyEntityId",
                table: "Drivers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyEntityId1",
                table: "Drivers",
                column: "LogisticsCompanyEntityId1",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_LogisticsCompanies_LogisticsCompanyEntityId1",
                table: "Drivers");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "LogisticsCompanyEntityId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "LogisticsCompanyId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "LogisticsCompanyEntityId",
                table: "Drivers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "LogisticsCompanyId",
                table: "Drivers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LogisticsCompanyId",
                table: "Vehicles",
                column: "LogisticsCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LogisticsCompanyId",
                table: "Drivers",
                column: "LogisticsCompanyId");

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
    }
}
