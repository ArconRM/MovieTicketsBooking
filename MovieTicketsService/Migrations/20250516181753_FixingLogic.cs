using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicketsService.Migrations
{
    /// <inheritdoc />
    public partial class FixingLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Seats_ScreeningRoomUUID",
                table: "Seats",
                column: "ScreeningRoomUUID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreeningRooms_TheaterUUID",
                table: "ScreeningRooms",
                column: "TheaterUUID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShows_ScreeningRoomUUID",
                table: "MovieShows",
                column: "ScreeningRoomUUID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MovieShowUUID",
                table: "Bookings",
                column: "MovieShowUUID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SeatUUID",
                table: "Bookings",
                column: "SeatUUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_MovieShows_MovieShowUUID",
                table: "Bookings",
                column: "MovieShowUUID",
                principalTable: "MovieShows",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Seats_SeatUUID",
                table: "Bookings",
                column: "SeatUUID",
                principalTable: "Seats",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShows_ScreeningRooms_ScreeningRoomUUID",
                table: "MovieShows",
                column: "ScreeningRoomUUID",
                principalTable: "ScreeningRooms",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreeningRooms_Theaters_TheaterUUID",
                table: "ScreeningRooms",
                column: "TheaterUUID",
                principalTable: "Theaters",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ScreeningRooms_ScreeningRoomUUID",
                table: "Seats",
                column: "ScreeningRoomUUID",
                principalTable: "ScreeningRooms",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_MovieShows_MovieShowUUID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Seats_SeatUUID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieShows_ScreeningRooms_ScreeningRoomUUID",
                table: "MovieShows");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreeningRooms_Theaters_TheaterUUID",
                table: "ScreeningRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ScreeningRooms_ScreeningRoomUUID",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ScreeningRoomUUID",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_ScreeningRooms_TheaterUUID",
                table: "ScreeningRooms");

            migrationBuilder.DropIndex(
                name: "IX_MovieShows_ScreeningRoomUUID",
                table: "MovieShows");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_MovieShowUUID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_SeatUUID",
                table: "Bookings");
        }
    }
}
