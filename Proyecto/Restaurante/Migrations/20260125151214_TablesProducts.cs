using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Migrations
{
    /// <inheritdoc />
    public partial class TablesProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTOSINGREDIENTES",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOSINGREDIENTES", x => new { x.IdProducto, x.IdIngrediente });
                    table.ForeignKey(
                        name: "FK_PRODUCTOSINGREDIENTES_INGREDIENTES_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "INGREDIENTES",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTOSINGREDIENTES_PRODUCTOS_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "PRODUCTOS",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TIPOSPROMOCIONES",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOSPROMOCIONES", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "PROMOCIONES",
                columns: table => new
                {
                    IdPromocion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(765)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROMOCIONES", x => x.IdPromocion);
                    table.ForeignKey(
                        name: "FK_PROMOCIONES_TIPOSPROMOCIONES_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "TIPOSPROMOCIONES",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOSINGREDIENTES_IdIngrediente",
                table: "PRODUCTOSINGREDIENTES",
                column: "IdIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_PROMOCIONES_IdTipo",
                table: "PROMOCIONES",
                column: "IdTipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTOSINGREDIENTES");

            migrationBuilder.DropTable(
                name: "PROMOCIONES");

            migrationBuilder.DropTable(
                name: "TIPOSPROMOCIONES");
        }
    }
}
