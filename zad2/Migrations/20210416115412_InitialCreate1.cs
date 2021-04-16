using Microsoft.EntityFrameworkCore.Migrations;

namespace zad2.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DownloadWeathers");

            migrationBuilder.CreateTable(
                name: "WeatherForDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clouds = table.Column<string>(type: "TEXT", nullable: true),
                    temp = table.Column<float>(type: "REAL", nullable: false),
                    feels_like = table.Column<float>(type: "REAL", nullable: false),
                    temp_min = table.Column<float>(type: "REAL", nullable: false),
                    temp_max = table.Column<float>(type: "REAL", nullable: false),
                    pressure = table.Column<float>(type: "REAL", nullable: false),
                    humidity = table.Column<float>(type: "REAL", nullable: false),
                    windSpeed = table.Column<float>(type: "REAL", nullable: false),
                    windDeg = table.Column<float>(type: "REAL", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForDB", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForDB");

            migrationBuilder.CreateTable(
                name: "DownloadWeathers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cod = table.Column<int>(type: "INTEGER", nullable: false),
                    dt = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    timezone = table.Column<int>(type: "INTEGER", nullable: false),
                    visibility = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadWeathers", x => x.id);
                });
        }
    }
}
