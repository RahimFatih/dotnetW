using Microsoft.EntityFrameworkCore.Migrations;

namespace alamakota249031.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alamakota",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    string1 = table.Column<string>(type: "TEXT", nullable: true),
                    string2 = table.Column<string>(type: "TEXT", nullable: true),
                    stringSum = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alamakota", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alamakota");
        }
    }
}
