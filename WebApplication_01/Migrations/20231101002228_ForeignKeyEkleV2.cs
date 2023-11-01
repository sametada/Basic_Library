using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_01.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyEkleV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KitapTuruİd",
                table: "Kitaplar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KitapTuruİd",
                table: "Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
