using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Site.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskModelOneToOneWithUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssigneeUser",
                table: "Tasks",
                newName: "AssigneeUserId");

            migrationBuilder.RenameColumn(
                name: "AssignedUser",
                table: "Tasks",
                newName: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedUserId",
                table: "Tasks",
                column: "AssignedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigneeUserId",
                table: "Tasks",
                column: "AssigneeUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssignedUserId",
                table: "Tasks",
                column: "AssignedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssigneeUserId",
                table: "Tasks",
                column: "AssigneeUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssignedUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssigneeUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignedUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssigneeUserId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "AssigneeUserId",
                table: "Tasks",
                newName: "AssigneeUser");

            migrationBuilder.RenameColumn(
                name: "AssignedUserId",
                table: "Tasks",
                newName: "AssignedUser");
        }
    }
}
