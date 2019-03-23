using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallApi.Migrations
{
    public partial class libros_modificada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Title",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
