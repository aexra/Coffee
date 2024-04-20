using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompletedMeetings",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Duration = table.Column<short>(type: "INTEGER", nullable: false),
                    User1Id = table.Column<ulong>(type: "INTEGER", nullable: true),
                    User2Id = table.Column<ulong>(type: "INTEGER", nullable: true),
                    Success = table.Column<bool>(type: "INTEGER", nullable: false),
                    CancellerId = table.Column<ulong>(type: "INTEGER", nullable: true),
                    ImagesBlobbed = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedMeetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BytesString = table.Column<string>(type: "TEXT", nullable: true),
                    CompletedMeetingId = table.Column<ulong>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_CompletedMeetings_CompletedMeetingId",
                        column: x => x.CompletedMeetingId,
                        principalTable: "CompletedMeetings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HiredSince = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    AvatarId = table.Column<ulong>(type: "INTEGER", nullable: true),
                    MeetingsCount = table.Column<uint>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    Hobbies = table.Column<string>(type: "TEXT", nullable: true),
                    Pets = table.Column<string>(type: "TEXT", nullable: true),
                    Coffee = table.Column<string>(type: "TEXT", nullable: true),
                    Telegram = table.Column<string>(type: "TEXT", nullable: true),
                    Vk = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Images_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FutureMeetings",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Duration = table.Column<short>(type: "INTEGER", nullable: false),
                    User1Id = table.Column<ulong>(type: "INTEGER", nullable: true),
                    User2Id = table.Column<ulong>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FutureMeetings_Users_User1Id",
                        column: x => x.User1Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FutureMeetings_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User1Id = table.Column<ulong>(type: "INTEGER", nullable: true),
                    User2Id = table.Column<ulong>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_User1Id",
                        column: x => x.User1Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedMeetings_CancellerId",
                table: "CompletedMeetings",
                column: "CancellerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedMeetings_User1Id",
                table: "CompletedMeetings",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedMeetings_User2Id",
                table: "CompletedMeetings",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_FutureMeetings_User1Id",
                table: "FutureMeetings",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_FutureMeetings_User2Id",
                table: "FutureMeetings",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CompletedMeetingId",
                table: "Images",
                column: "CompletedMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_User1Id",
                table: "Rooms",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_User2Id",
                table: "Rooms",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AvatarId",
                table: "Users",
                column: "AvatarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedMeetings_Users_CancellerId",
                table: "CompletedMeetings",
                column: "CancellerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedMeetings_Users_User1Id",
                table: "CompletedMeetings",
                column: "User1Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedMeetings_Users_User2Id",
                table: "CompletedMeetings",
                column: "User2Id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedMeetings_Users_CancellerId",
                table: "CompletedMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedMeetings_Users_User1Id",
                table: "CompletedMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedMeetings_Users_User2Id",
                table: "CompletedMeetings");

            migrationBuilder.DropTable(
                name: "FutureMeetings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "CompletedMeetings");
        }
    }
}
