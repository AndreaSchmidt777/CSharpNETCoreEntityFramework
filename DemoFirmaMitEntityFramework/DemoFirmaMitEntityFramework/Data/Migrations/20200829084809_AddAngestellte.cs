using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoFirmaMitEntityFramework.Data.Migrations
{
    public partial class AddAngestellte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mitarbeiter",
                columns: table => new
                {
                    MitarbeiterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(maxLength: 50, nullable: false),
                    Nachname = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitarbeiter", x => x.MitarbeiterID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mitarbeiter");
        }
    }
}
