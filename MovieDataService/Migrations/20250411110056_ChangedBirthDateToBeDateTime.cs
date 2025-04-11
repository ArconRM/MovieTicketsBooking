using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataService.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBirthDateToBeDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirth",
                table: "Persons",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateBirth",
                table: "Persons",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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
