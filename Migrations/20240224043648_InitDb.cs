using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1api.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDriver = table.Column<int>(type: "int", nullable: false),
                    Titles = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Podiums = table.Column<int>(type: "int", nullable: false),
                    Poles = table.Column<int>(type: "int", nullable: false),
                    FastestLaps = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    DebutYear = table.Column<int>(type: "int", nullable: false),
                    CurrentTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebutTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDriverStats = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_DriverStats_IdDriverStats",
                        column: x => x.IdDriverStats,
                        principalTable: "DriverStats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_IdDriverStats",
                table: "Drivers",
                column: "IdDriverStats",
                unique: true,
                filter: "[IdDriverStats] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "DriverStats");
        }
    }
}
