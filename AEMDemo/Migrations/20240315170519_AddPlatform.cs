using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEMDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlatformDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    uniqueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WellDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    platformId = table.Column<int>(type: "int", nullable: false),
                    uniqueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlatformDtoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellDto", x => x.id);
                    table.ForeignKey(
                        name: "FK_WellDto_PlatformDto_PlatformDtoid",
                        column: x => x.PlatformDtoid,
                        principalTable: "PlatformDto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WellDto_PlatformDtoid",
                table: "WellDto",
                column: "PlatformDtoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WellDto");

            migrationBuilder.DropTable(
                name: "PlatformDto");
        }
    }
}
