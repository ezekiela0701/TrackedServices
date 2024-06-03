using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class databaseupdatefixederror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Services_ServiceId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Services_ServiceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ServiceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ServiceId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IdService",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdService",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdClient",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Services_ClientId",
                table: "Services",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                table: "Services",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Clients_ClientId",
                table: "Services",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_UserId",
                table: "Services",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Clients_ClientId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UserId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ClientId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UserId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Services");

            migrationBuilder.AddColumn<Guid>(
                name: "IdService",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdService",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_ServiceId",
                table: "Users",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ServiceId",
                table: "Clients",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Services_ServiceId",
                table: "Clients",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Services_ServiceId",
                table: "Users",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
