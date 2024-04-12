using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinDef.Data.Migrations
{
    public partial class add_table_Personal_Operacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalOperaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FuerzaId = table.Column<int>(nullable: true),
                    OperacionId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalOperaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalOperaciones_Fuerzas_FuerzaId",
                        column: x => x.FuerzaId,
                        principalTable: "Fuerzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalOperaciones_Operaciones_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalOperaciones_FuerzaId",
                table: "PersonalOperaciones",
                column: "FuerzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalOperaciones_OperacionId",
                table: "PersonalOperaciones",
                column: "OperacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalOperaciones");
        }
    }
}
