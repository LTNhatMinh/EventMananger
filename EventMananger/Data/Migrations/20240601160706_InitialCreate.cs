using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventMananger.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOrganizer = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventFunding = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipant",
                columns: table => new
                {
                    EventParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventParticipantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventParticipantEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventParticipantPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipant", x => x.EventParticipantId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventParticipant");
        }
    }
}
