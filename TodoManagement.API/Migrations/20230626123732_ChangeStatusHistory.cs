using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStatusHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeTodoStatusHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChangedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CurrentStatus = table.Column<int>(type: "integer", nullable: false),
                    ToDoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeTodoStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeTodoStatusHistories_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeTodoStatusHistories_ToDoId",
                table: "ChangeTodoStatusHistories",
                column: "ToDoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeTodoStatusHistories");
        }
    }
}
