using Microsoft.EntityFrameworkCore.Migrations;

namespace MinDef.Data.Migrations
{
    public partial class add_column_tendencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IndicarTendencia",
                table: "IndicadoresBase",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValorAnteriorTendencia",
                table: "IndicadoresBase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndicarTendencia",
                table: "IndicadoresBase");

            migrationBuilder.DropColumn(
                name: "ValorAnteriorTendencia",
                table: "IndicadoresBase");
        }
    }
}
