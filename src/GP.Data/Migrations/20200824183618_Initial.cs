using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GP.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrimonios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MarcaId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimonios_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_MarcaId",
                table: "Patrimonios",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patrimonios");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
