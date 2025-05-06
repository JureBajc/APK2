using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APKtest.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merilna_Naprava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zemljepisna_Dolzina = table.Column<float>(type: "real", nullable: false),
                    Zempljepisna_Sirina = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merilna_Naprava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metrolog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum_Zaposlitve = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrolog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meritve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum_Meritve = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<float>(type: "real", nullable: false),
                    Vlažnost = table.Column<float>(type: "real", nullable: false),
                    Okvara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Merilna_NapravaId = table.Column<int>(type: "int", nullable: false),
                    MetrologId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meritve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meritve_Merilna_Naprava_Merilna_NapravaId",
                        column: x => x.Merilna_NapravaId,
                        principalTable: "Merilna_Naprava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meritve_Metrolog_MetrologId",
                        column: x => x.MetrologId,
                        principalTable: "Metrolog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meritve_Merilna_NapravaId",
                table: "Meritve",
                column: "Merilna_NapravaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meritve_MetrologId",
                table: "Meritve",
                column: "MetrologId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meritve");

            migrationBuilder.DropTable(
                name: "Merilna_Naprava");

            migrationBuilder.DropTable(
                name: "Metrolog");
        }
    }
}
