using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_mxm_webDiet.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Dietas",
                columns: table => new
                {
                    UserCpf = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    responseApiDTOId = table.Column<int>(type: "INTEGER", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietas", x => x.UserCpf);
                    table.ForeignKey(
                        name: "FK_Dietas_ResponseApiDTO_responseApiDTOId",
                        column: x => x.responseApiDTOId,
                        principalTable: "ResponseApiDTO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dietas_responseApiDTOId",
                table: "Dietas",
                column: "responseApiDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseApiDTO_ChoiceId",
                table: "ResponseApiDTO",
                column: "ChoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dietas");

            migrationBuilder.DropTable(
                name: "ResponseApiDTO");

            migrationBuilder.DropTable(
                name: "ChoiceDTO");
        }
    }
}
