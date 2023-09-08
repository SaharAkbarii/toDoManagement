using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkSpaceSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SlackWebHookUrl",
                table: "WorkspaceSettings",
                newName: "TargetNotificationAddress");

            migrationBuilder.AddColumn<int>(
                name: "Channel",
                table: "WorkspaceSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Channel",
                table: "WorkspaceSettings");

            migrationBuilder.RenameColumn(
                name: "TargetNotificationAddress",
                table: "WorkspaceSettings",
                newName: "SlackWebHookUrl");
        }
    }
}
