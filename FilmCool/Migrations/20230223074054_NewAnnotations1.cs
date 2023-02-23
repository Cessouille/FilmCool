using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmCool.Migrations
{
    /// <inheritdoc />
    public partial class NewAnnotations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_note",
                table: "t_j_notation_not");

            migrationBuilder.AlterColumn<string>(
                name: "utl_pwd",
                table: "t_e_utilisateur_utl",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AddCheckConstraint(
                name: "ck_not_note",
                table: "t_j_notation_not",
                sql: "not_note between 0 and 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_not_note",
                table: "t_j_notation_not");

            migrationBuilder.AlterColumn<string>(
                name: "utl_pwd",
                table: "t_e_utilisateur_utl",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddCheckConstraint(
                name: "ck_note",
                table: "t_j_notation_not",
                sql: "not_note between 0 and 5");
        }
    }
}
