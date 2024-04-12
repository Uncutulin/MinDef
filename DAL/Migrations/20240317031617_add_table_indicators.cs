using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinDef.Data.Migrations
{
    public partial class add_table_indicators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndicadoresBase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    Icono = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PrimerSubTitulo = table.Column<string>(nullable: true),
                    SegundoSubTituto = table.Column<string>(nullable: true),
                    PrimerValor = table.Column<string>(nullable: true),
                    SegundoValor = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Porcentaje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadoresBase", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicadoresBase");
        }
    }
}
