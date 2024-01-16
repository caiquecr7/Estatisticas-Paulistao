using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstatisticasFutebol.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "RoundMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Away_Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Away_Score = table.Column<int>(type: "int", nullable: false),
                    Home_Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Home_Score = table.Column<int>(type: "int", nullable: false),
                    Round_Number = table.Column<int>(type: "int", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundMatches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundMatches");

            migrationBuilder.CreateTable(
                name: "GamesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    AwayTeam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    HomeTeam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesInfo", x => x.Id);
                });
        }
    }
}
