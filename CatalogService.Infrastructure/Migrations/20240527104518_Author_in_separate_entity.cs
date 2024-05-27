using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Author_in_separate_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                type: "uuid",
                maxLength: 250,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
