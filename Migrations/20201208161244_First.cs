using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteVisitantes.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Depto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Empresa = table.Column<string>(maxLength: 50, nullable: false),
                    HoraChegada = table.Column<DateTime>(nullable: false),
                    HoraSaida = table.Column<DateTime>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitantes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Depto" },
                values: new object[,]
                {
                    { 1, "Sala" },
                    { 2, "Quarto" },
                    { 3, "Cozinha" },
                    { 4, "Banheiro" },
                    { 5, "Garagem" }
                });

            migrationBuilder.InsertData(
                table: "Visitantes",
                columns: new[] { "Id", "Data", "DepartamentoId", "Empresa", "HoraChegada", "HoraSaida", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Empresa 05", new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "Eric Figueiredo" },
                    { 2, new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Empresa 04", new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "Cristiniane Queiroz" },
                    { 3, new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Empresa 03", new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "Madalena Puca" },
                    { 4, new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Empresa 02", new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "Miguel Comitre" },
                    { 5, new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Empresa 01", new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "Márcia do Celso" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Visitantes");
        }
    }
}
