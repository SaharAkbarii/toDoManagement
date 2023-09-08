using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class relatedtodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatedTodos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ToDoId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedToDoId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelationStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedTodos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedTodos_ToDos_RelatedToDoId",
                        column: x => x.RelatedToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatedTodos_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedTodos_RelatedToDoId",
                table: "RelatedTodos",
                column: "RelatedToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedTodos_ToDoId",
                table: "RelatedTodos",
                column: "ToDoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedTodos");
        }
    }
}
