using Microsoft.EntityFrameworkCore.Migrations;

namespace MinDef.Data.Migrations
{
    public partial class add_column_Orden_to_table_OrganismoOrigen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Orden",
                table: "OrganismoOrigen",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orden",
                table: "OrganismoOrigen");
        }
    }
}
