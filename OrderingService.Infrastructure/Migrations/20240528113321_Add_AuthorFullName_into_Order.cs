using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderingService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_AuthorFullName_into_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookAuthor",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "AuthorFullName_LastName",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorFullName_MiddleName",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorFullName_Name",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorFullName_LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AuthorFullName_MiddleName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AuthorFullName_Name",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "BookAuthor",
                table: "Orders",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
