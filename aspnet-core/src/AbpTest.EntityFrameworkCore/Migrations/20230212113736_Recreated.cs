﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpTest.Migrations
{
    /// <inheritdoc />
    public partial class Recreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelHotelRoomCategory");

            migrationBuilder.DropTable(
                name: "HotelRoomCategories");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.CreateTable(
                name: "AppHotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppHotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoomCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    AreaFrom = table.Column<int>(type: "int", nullable: false),
                    PriceForSinglePlacement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceForDoublePlacement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoomCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoomCategories_AppHotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "AppHotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoomCategories_HotelId",
                table: "AppRoomCategories",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoomCategories");

            migrationBuilder.DropTable(
                name: "AppHotels");

            migrationBuilder.CreateTable(
                name: "HotelRoomCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaFrom = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceFrom = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelHotelRoomCategory",
                columns: table => new
                {
                    HotelRoomCategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    HotelsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelHotelRoomCategory", x => new { x.HotelRoomCategoriesId, x.HotelsId });
                    table.ForeignKey(
                        name: "FK_HotelHotelRoomCategory_HotelRoomCategories_HotelRoomCategoriesId",
                        column: x => x.HotelRoomCategoriesId,
                        principalTable: "HotelRoomCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelHotelRoomCategory_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelHotelRoomCategory_HotelsId",
                table: "HotelHotelRoomCategory",
                column: "HotelsId");
        }
    }
}
