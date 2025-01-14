using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentApp.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToPlayerForTeamStep2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamModelTeamId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "TeamModelTeamId",
                table: "Players",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamModelTeamId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Players",
                newName: "TeamModelTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                newName: "IX_Players_TeamModelTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamModelTeamId",
                table: "Players",
                column: "TeamModelTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }
    }
}
