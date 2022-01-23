using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountWon = table.Column<int>(type: "int", nullable: false),
                    CountDraw = table.Column<int>(type: "int", nullable: false),
                    CountLose = table.Column<int>(type: "int", nullable: false),
                    CountHeadsGoals = table.Column<int>(type: "int", nullable: false),
                    CountMissedGoals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
