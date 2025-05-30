using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicketsService.Migrations
{
    /// <inheritdoc />
    public partial class ReplacedDiscountWithTotalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Bookings");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Bookings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Bookings");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Bookings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
