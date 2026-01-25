using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIASPRODUCTOS",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIASPRODUCTOS", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "DETALLESPEDIDOS",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETALLESPEDIDOS", x => new { x.IdProducto, x.IdPedido });
                });

            migrationBuilder.CreateTable(
                name: "ESTADOSPEDIDOS",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOSPEDIDOS", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOSRESERVAS",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOSRESERVAS", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "INGREDIENTES",
                columns: table => new
                {
                    IdIngrediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(765)", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENTES", x => x.IdIngrediente);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTOS",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(765)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagenURL = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IdCategoriaProducto = table.Column<int>(type: "int", nullable: false),
                    IdPromocion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOS", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_PRODUCTOS_CATEGORIASPRODUCTOS_IdCategoriaProducto",
                        column: x => x.IdCategoriaProducto,
                        principalTable: "CATEGORIASPRODUCTOS",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOS",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdMesa = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_PEDIDOS_ESTADOSPEDIDOS_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "ESTADOSPEDIDOS",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PEDIDOS_MESAS_IdMesa",
                        column: x => x.IdMesa,
                        principalTable: "MESAS",
                        principalColumn: "IdMesa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PEDIDOS_USUARIOS_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESERVAS",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaReserva = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdMesa = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVAS", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_RESERVAS_ESTADOSPEDIDOS_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "ESTADOSPEDIDOS",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESERVAS_MESAS_IdMesa",
                        column: x => x.IdMesa,
                        principalTable: "MESAS",
                        principalColumn: "IdMesa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESERVAS_USUARIOS_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_IdEstado",
                table: "PEDIDOS",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_IdMesa",
                table: "PEDIDOS",
                column: "IdMesa");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_IdUsuario",
                table: "PEDIDOS",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOS_IdCategoriaProducto",
                table: "PRODUCTOS",
                column: "IdCategoriaProducto");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVAS_IdEstado",
                table: "RESERVAS",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVAS_IdMesa",
                table: "RESERVAS",
                column: "IdMesa");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVAS_IdUsuario",
                table: "RESERVAS",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DETALLESPEDIDOS");

            migrationBuilder.DropTable(
                name: "ESTADOSRESERVAS");

            migrationBuilder.DropTable(
                name: "INGREDIENTES");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "PRODUCTOS");

            migrationBuilder.DropTable(
                name: "RESERVAS");

            migrationBuilder.DropTable(
                name: "CATEGORIASPRODUCTOS");

            migrationBuilder.DropTable(
                name: "ESTADOSPEDIDOS");
        }
    }
}
