using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RESTAURANTES",
                columns: table => new
                {
                    IdRestaurante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(510)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CapacidadTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTAURANTES", x => x.IdRestaurante);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "MESAS",
                columns: table => new
                {
                    IdMesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    CodQR = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IdRestaurante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MESAS", x => x.IdMesa);
                    table.ForeignKey(
                        name: "FK_MESAS_RESTAURANTES_IdRestaurante",
                        column: x => x.IdRestaurante,
                        principalTable: "RESTAURANTES",
                        principalColumn: "IdRestaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(510)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_USUARIOS_ROLES_IdRol",
                        column: x => x.IdRol,
                        principalTable: "ROLES",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HORARIOSTRABAJADOR",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diaSemana = table.Column<int>(type: "int", nullable: false),
                    horaentrada = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaSalida = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HORARIOSTRABAJADOR", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_HORARIOSTRABAJADOR_USUARIOS_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HORARIOSTRABAJADOR_IdUsuario",
                table: "HORARIOSTRABAJADOR",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_MESAS_IdRestaurante",
                table: "MESAS",
                column: "IdRestaurante");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_Email",
                table: "USUARIOS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_IdRol",
                table: "USUARIOS",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HORARIOSTRABAJADOR");

            migrationBuilder.DropTable(
                name: "MESAS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "RESTAURANTES");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}
