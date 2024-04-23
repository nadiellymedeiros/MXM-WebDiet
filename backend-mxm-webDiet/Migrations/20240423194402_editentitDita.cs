using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_mxm_webDiet.Migrations
{
    /// <inheritdoc />
    public partial class editentitDita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dietas_Users_UserId",
                table: "Dietas");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Dietas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                table: "Dietas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dietas_Users_UserId",
                table: "Dietas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dietas_Users_UserId",
                table: "Dietas");

            migrationBuilder.DropColumn(
                name: "UserCpf",
                table: "Dietas");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Dietas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dietas_Users_UserId",
                table: "Dietas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
