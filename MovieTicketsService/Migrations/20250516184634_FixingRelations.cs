using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicketsService.Migrations
{
    /// <inheritdoc />
    public partial class FixingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ScreeningRoomUUID",
                table: "Seats",
                newName: "ScreeningRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_ScreeningRoomUUID",
                table: "Seats",
                newName: "IX_Seats_ScreeningRoomId");

            migrationBuilder.RenameColumn(
                name: "TheaterUUID",
                table: "ScreeningRooms",
                newName: "TheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_ScreeningRooms_TheaterUUID",
                table: "ScreeningRooms",
                newName: "IX_ScreeningRooms_TheaterId");

            migrationBuilder.RenameColumn(
                name: "ScreeningRoomUUID",
                table: "MovieShows",
                newName: "ScreeningRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieShows_ScreeningRoomUUID",
                table: "MovieShows",
                newName: "IX_MovieShows_ScreeningRoomId");

            migrationBuilder.RenameColumn(
                name: "SeatUUID",
                table: "Bookings",
                newName: "SeatId");

            migrationBuilder.RenameColumn(
                name: "MovieShowUUID",
                table: "Bookings",
                newName: "MovieShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_SeatUUID",
                table: "Bookings",
                newName: "IX_Bookings_SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_MovieShowUUID",
                table: "Bookings",
                newName: "IX_Bookings_MovieShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_MovieShows_MovieShowId",
                table: "Bookings",
                column: "MovieShowId",
                principalTable: "MovieShows",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Seats_SeatId",
                table: "Bookings",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShows_ScreeningRooms_ScreeningRoomId",
                table: "MovieShows",
                column: "ScreeningRoomId",
                principalTable: "ScreeningRooms",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreeningRooms_Theaters_TheaterId",
                table: "ScreeningRooms",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ScreeningRooms_ScreeningRoomId",
                table: "Seats",
                column: "ScreeningRoomId",
                principalTable: "ScreeningRooms",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_MovieShows_MovieShowId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Seats_SeatId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieShows_ScreeningRooms_ScreeningRoomId",
                table: "MovieShows");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreeningRooms_Theaters_TheaterId",
                table: "ScreeningRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ScreeningRooms_ScreeningRoomId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "ScreeningRoomId",
                table: "Seats",
                newName: "ScreeningRoomUUID");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_ScreeningRoomId",
                table: "Seats",
                newName: "IX_Seats_ScreeningRoomUUID");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "ScreeningRooms",
                newName: "TheaterUUID");

            migrationBuilder.RenameIndex(
                name: "IX_ScreeningRooms_TheaterId",
                table: "ScreeningRooms",
                newName: "IX_ScreeningRooms_TheaterUUID");

            migrationBuilder.RenameColumn(
                name: "ScreeningRoomId",
                table: "MovieShows",
                newName: "ScreeningRoomUUID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieShows_ScreeningRoomId",
                table: "MovieShows",
                newName: "IX_MovieShows_ScreeningRoomUUID");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Bookings",
                newName: "SeatUUID");

            migrationBuilder.RenameColumn(
                name: "MovieShowId",
                table: "Bookings",
                newName: "MovieShowUUID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_SeatId",
                table: "Bookings",
                newName: "IX_Bookings_SeatUUID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_MovieShowId",
                table: "Bookings",
                newName: "IX_Bookings_MovieShowUUID");

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
    }
}
