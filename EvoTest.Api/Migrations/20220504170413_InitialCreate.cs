using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoTest.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassengerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId = table.Column<int>(type: "int", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: true),
                    FlyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AirLines_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Airports_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Airports_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_PassengerTypes_PassengerTypeId",
                        column: x => x.PassengerTypeId,
                        principalTable: "PassengerTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AirLineId",
                table: "Reservations",
                column: "AirLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DestinationId",
                table: "Reservations",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OriginId",
                table: "Reservations",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PassengerTypeId",
                table: "Reservations",
                column: "PassengerTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AirLines");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "PassengerTypes");
        }
    }
}
