using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infractructure.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplane",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountPassenger = table.Column<int>(type: "int", nullable: false),
                    Maxweight = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplane", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airport1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirplaneLimit = table.Column<int>(type: "int", nullable: false),
                    AmountAirplane = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airport2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirplaneLimit = table.Column<int>(type: "int", nullable: false),
                    AmountAirplane = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weigth = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false),
                    AirportArrivalId = table.Column<int>(type: "int", nullable: false),
                    AirportDepartureId = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Airplane_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Airport1_AirportArrivalId",
                        column: x => x.AirportArrivalId,
                        principalTable: "Airport1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Airport2_AirportDepartureId",
                        column: x => x.AirportDepartureId,
                        principalTable: "Airport2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Passenger_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passenger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AirplaneId",
                table: "Ticket",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AirportArrivalId",
                table: "Ticket",
                column: "AirportArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AirportDepartureId",
                table: "Ticket",
                column: "AirportDepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerId",
                table: "Ticket",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Airplane");

            migrationBuilder.DropTable(
                name: "Airport1");

            migrationBuilder.DropTable(
                name: "Airport2");

            migrationBuilder.DropTable(
                name: "Passenger");
        }
    }
}
