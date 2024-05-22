using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderingService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RenterFullName_Name = table.Column<string>(type: "text", nullable: false),
                    RenterFullName_LastName = table.Column<string>(type: "text", nullable: false),
                    RenterFullName_MiddleName = table.Column<string>(type: "text", nullable: false),
                    RenterAddress_Street = table.Column<string>(type: "text", nullable: false),
                    RenterAddress_City = table.Column<string>(type: "text", nullable: false),
                    RenterAddress_State = table.Column<string>(type: "text", nullable: false),
                    RenterAddress_Country = table.Column<string>(type: "text", nullable: false),
                    RenterAddress_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    RenterId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PlannedReturnDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ActualReturnDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    BookTitle = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BookAuthor = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RenterId",
                table: "Orders",
                column: "RenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Renters");
        }
    }
}
