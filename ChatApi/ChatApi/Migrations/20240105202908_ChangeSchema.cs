using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "originUserId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "recipientUserId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Chats",
                newName: "chatId");

            migrationBuilder.AddColumn<string>(
                name: "chatName",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UsersChats",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    chatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersChats", x => new { x.userId, x.chatId });
                    table.ForeignKey(
                        name: "FK_UsersChats_Chats_chatId",
                        column: x => x.chatId,
                        principalTable: "Chats",
                        principalColumn: "chatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersChats_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersChats_chatId",
                table: "UsersChats",
                column: "chatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersChats");

            migrationBuilder.DropColumn(
                name: "chatName",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "chatId",
                table: "Chats",
                newName: "ChatId");

            migrationBuilder.AddColumn<Guid>(
                name: "originUserId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "recipientUserId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
