using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CD_USUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_USUARIO = table.Column<string>(nullable: true),
                    DS_CPF = table.Column<string>(nullable: true),
                    DS_RG = table.Column<string>(nullable: true),
                    DT_EXPEDICAO = table.Column<DateTime>(nullable: false),
                    DS_ORGAO_EXPEDITOR = table.Column<string>(nullable: true),
                    DS_UF = table.Column<string>(nullable: true),
                    DT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    DS_SEXO = table.Column<string>(nullable: true),
                    DS_ESTADO_CIVIL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CD_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    CD_ENDERECO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_CEP = table.Column<string>(nullable: true),
                    DS_LOGRADOURO = table.Column<string>(nullable: true),
                    DS_NUMERO = table.Column<string>(nullable: true),
                    DS_COMPLEMENTO = table.Column<string>(nullable: true),
                    DS_BAIRRO = table.Column<string>(nullable: true),
                    DS_CIDADE = table.Column<string>(nullable: true),
                    DS_UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.CD_ENDERECO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
