using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataService.Migrations
{
    /// <inheritdoc />
    public partial class MadeDescriptionAndNationalityNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Persons",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Persons",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

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
            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Persons",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Persons",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

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
