using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpTest.Migrations
{
    /// <inheritdoc />
    public partial class Hotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelRoomCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaFrom = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelHotelRoomCategory");

            migrationBuilder.DropTable(
                name: "HotelRoomCategories");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
