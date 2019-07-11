using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace j2p.Infra.Data.Migrations
{
    public partial class setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 36, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    Picture = table.Column<string>(maxLength: 200, nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 36, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Limit = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    IdOwner = table.Column<Guid>(nullable: true),
                    PlayerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Player_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdOwner",
                table: "Event",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Event_PlayerId",
                table: "Event",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_EventId",
                table: "Player",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Event_EventId",
                table: "Player",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Player_IdOwner",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Player_PlayerId",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
