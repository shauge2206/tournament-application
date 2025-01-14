using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTestTeamsAndPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamModelTeamId",
                table: "Players",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MaxPlayers = table.Column<int>(type: "INTEGER", nullable: false),
                    MinPlayers = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("4fa85f64-5717-4562-b3fc-2c963f66afa6"),
                column: "TeamModelTeamId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa6"),
                column: "TeamModelTeamId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("8fa85f64-5717-4562-b3fc-2c963f66afa6"),
                column: "TeamModelTeamId",
                value: null);

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "MaxPlayers", "MinPlayers", "Name" },
                values: new object[,]
                {
                    { new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"), 10, 5, "Alpha Team" },
                    { new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6"), 8, 3, "Beta Squad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamModelTeamId",
                table: "Players",
                column: "TeamModelTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamModelTeamId",
                table: "Players",
                column: "TeamModelTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamModelTeamId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamModelTeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamModelTeamId",
                table: "Players");
        }
    }
}
