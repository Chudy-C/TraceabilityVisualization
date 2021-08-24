using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TraceabilityVisualization.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KomoraWozek",
                columns: table => new
                {
                    ID_Trace = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr_wozka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Typ_cewki = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kolor_cewki = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TS_KOM1 = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomoraWozek", x => x.ID_Trace);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KomoraWozek");
        }
    }
}
