using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAprovement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedById",
                table: "ToDos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "ToDos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ToDos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ApprovedById",
                table: "ToDos",
                column: "ApprovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_People_ApprovedById",
                table: "ToDos",
                column: "ApprovedById",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_People_ApprovedById",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_ApprovedById",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ToDos");
        }
    }
}
