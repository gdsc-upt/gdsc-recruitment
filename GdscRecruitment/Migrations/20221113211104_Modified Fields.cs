using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GdscRecruitment.Migrations
{
    public partial class ModifiedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRequiered",
                table: "Fields",
                newName: "IsRequired");

            migrationBuilder.AlterColumn<string>(
                name: "Placeholder",
                table: "Fields",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRequired",
                table: "Fields",
                newName: "IsRequiered");

            migrationBuilder.AlterColumn<string>(
                name: "Placeholder",
                table: "Fields",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
