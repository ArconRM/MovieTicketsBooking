using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataService.Migrations
{
    /// <inheritdoc />
    public partial class AddedRatingToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<Guid>>(
                name: "GenresUUIDs",
                table: "Movies",
                type: "uuid[]",
                nullable: false,
                defaultValue: new List<Guid>(),
                oldClrType: typeof(List<Guid>),
                oldType: "uuid[]",
                oldDefaultValue: new List<Guid>());

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Movies",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.AlterColumn<List<Guid>>(
                name: "GenresUUIDs",
                table: "Movies",
                type: "uuid[]",
                nullable: false,
                defaultValue: new List<Guid>(),
                oldClrType: typeof(List<Guid>),
                oldType: "uuid[]",
                oldDefaultValue: new List<Guid>());
        }
    }
}
