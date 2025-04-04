using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataService.Migrations.MovieContextMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description =
                        table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ProducerUUID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Movies", x => x.UUID); });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DateBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Description =
                        table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AvatarUUID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Person", x => x.UUID); });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}