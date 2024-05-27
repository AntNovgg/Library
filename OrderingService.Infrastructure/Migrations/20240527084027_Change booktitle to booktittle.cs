using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderingService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changebooktitletobooktittle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookTitle",
                table: "Orders",
                newName: "BookTittle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookTittle",
                table: "Orders",
                newName: "BookTitle");
        }
    }
}
