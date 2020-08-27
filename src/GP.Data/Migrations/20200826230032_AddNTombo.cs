using Microsoft.EntityFrameworkCore.Migrations;

namespace GP.Data.Migrations
{
    public partial class AddNTombo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "TomboSequence",
                startValue: 1000L);

            migrationBuilder.AddColumn<int>(
                name: "NTombo",
                table: "Patrimonios",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR TomboSequence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "TomboSequence");

            migrationBuilder.DropColumn(
                name: "NTombo",
                table: "Patrimonios");
        }
    }
}
