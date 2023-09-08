﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class checklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckListItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    IsChecked = table.Column<bool>(type: "boolean", nullable: false),
                    ToDoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckListItems_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckListItems_ToDoId",
                table: "CheckListItems",
                column: "ToDoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListItems");
        }
    }
}
