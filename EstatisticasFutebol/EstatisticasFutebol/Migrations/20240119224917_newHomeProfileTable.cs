using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstatisticasFutebol.Migrations
{
    /// <inheritdoc />
    public partial class newHomeProfileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwayProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    VictoryOdd = table.Column<double>(type: "float", nullable: false, defaultValue: 30.0),
                    DrawOdd = table.Column<double>(type: "float", nullable: false, defaultValue: 35.0),
                    DefeatOdd = table.Column<double>(type: "float", nullable: false, defaultValue: 35.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwayProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    VictoryOdd = table.Column<double>(type: "float", nullable: false, defaultValue: 35.0),
                    DrawOdd = table.Column<double>(type: "float", nullable: false, defaultValue: 35.0),
                    DefeatOdd = table.Column<double>(type: "float", nullable: false, defaultValue: 3.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoundMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Away_Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Away_Score = table.Column<int>(type: "int", nullable: true),
                    Home_Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Home_Score = table.Column<int>(type: "int", nullable: true),
                    Round_Number = table.Column<int>(type: "int", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundMatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Goals_Scored = table.Column<int>(type: "int", nullable: false),
                    NationalRank = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    HomeProfile_Id = table.Column<int>(type: "int", nullable: true),
                    AwayProfile_Id = table.Column<int>(type: "int", nullable: true),
                    Group_Letter = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Matches = table.Column<int>(type: "int", nullable: true),
                    Victories = table.Column<int>(type: "int", nullable: true),
                    Draws = table.Column<int>(type: "int", nullable: true),
                    Defeats = table.Column<int>(type: "int", nullable: true),
                    Goals_For = table.Column<int>(type: "int", nullable: true),
                    Goals_Against = table.Column<int>(type: "int", nullable: true),
                    Goals_Difference = table.Column<int>(type: "int", nullable: true),
                    Conversion_Rate = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Team_AwayProfile",
                        column: x => x.AwayProfile_Id,
                        principalTable: "AwayProfile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Team_HomeProfile",
                        column: x => x.HomeProfile_Id,
                        principalTable: "HomeProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_AwayProfile_Id",
                table: "Team",
                column: "AwayProfile_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Team_HomeProfile_Id",
                table: "Team",
                column: "HomeProfile_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundMatches");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "AwayProfile");

            migrationBuilder.DropTable(
                name: "HomeProfile");
        }
    }
}
