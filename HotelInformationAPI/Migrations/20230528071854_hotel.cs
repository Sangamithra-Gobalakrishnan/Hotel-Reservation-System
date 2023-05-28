using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelInformationAPI.Migrations
{
    public partial class hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelInformation",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    MinimumPriceRange = table.Column<double>(type: "float", nullable: false),
                    MaximumPriceRange = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelInformation", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "RoomInformation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomInformation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomInformation_HotelInformation_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelInformation",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HotelInformation",
                columns: new[] { "HotelId", "Address", "AverageRating", "City", "ContactNumber", "Country", "Description", "MaximumPriceRange", "MinimumPriceRange", "Name", "NumberOfRooms" },
                values: new object[] { 101, "123 Main Street", 4.5, "New York City", "9867453212", "United States", "A luxurious hotel offering a memorable stay.", 400000.0, 5000.0, "Grand Hotel", 100 });

            migrationBuilder.CreateIndex(
                name: "IX_RoomInformation_HotelId",
                table: "RoomInformation",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomInformation");

            migrationBuilder.DropTable(
                name: "HotelInformation");
        }
    }
}
