using Microsoft.EntityFrameworkCore.Migrations;

namespace libreriaa_SLE.Migrations
{
    public partial class BookAuthorColumnRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
