using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_mxm_webDiet.Migrations
{
    /// <inheritdoc />
    public partial class editEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dietas",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Dietas");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Dietas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Dietas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Dietas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "responseApiDTOId",
                table: "Dietas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dietas",
                table: "Dietas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChoiceDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<string>(type: "TEXT", nullable: false),
                    Altura = table.Column<string>(type: "TEXT", nullable: false),
                    Peso = table.Column<string>(type: "TEXT", nullable: false),
                    Sexo = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseApiDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChoiceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseApiDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseApiDTO_ChoiceDTO_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "ChoiceDTO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dietas_responseApiDTOId",
                table: "Dietas",
                column: "responseApiDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Dietas_UserId",
                table: "Dietas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseApiDTO_ChoiceId",
                table: "ResponseApiDTO",
                column: "ChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dietas_ResponseApiDTO_responseApiDTOId",
                table: "Dietas",
                column: "responseApiDTOId",
                principalTable: "ResponseApiDTO",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dietas_Users_UserId",
                table: "Dietas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dietas_ResponseApiDTO_responseApiDTOId",
                table: "Dietas");

            migrationBuilder.DropForeignKey(
                name: "FK_Dietas_Users_UserId",
                table: "Dietas");

            migrationBuilder.DropTable(
                name: "ResponseApiDTO");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ChoiceDTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dietas",
                table: "Dietas");

            migrationBuilder.DropIndex(
                name: "IX_Dietas_responseApiDTOId",
                table: "Dietas");

            migrationBuilder.DropIndex(
                name: "IX_Dietas_UserId",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "responseApiDTOId",
                table: "Dietas");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Dietas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Altura",
                table: "Dietas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Idade",
                table: "Dietas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Dietas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Dietas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Dietas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dietas",
                table: "Dietas",
                column: "Cpf");
        }
    }
}
