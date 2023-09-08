using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class makingAsigneeOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_People_AssigneeId",
                table: "ToDos");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_People_AssigneeId",
                table: "ToDos",
                column: "AssigneeId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_People_AssigneeId",
                table: "ToDos");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_People_AssigneeId",
                table: "ToDos",
                column: "AssigneeId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
