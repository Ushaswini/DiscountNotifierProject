using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountNotifierAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Beacons",
                columns: table => new
                {
                    BeaconId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beacons", x => x.BeaconId);
                    table.ForeignKey(
                        name: "FK_Beacons_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    OfferText = table.Column<string>(type: "TEXT", nullable: true),
                    OriginalPrice = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    BeaconId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Beacons_BeaconId",
                        column: x => x.BeaconId,
                        principalTable: "Beacons",
                        principalColumn: "BeaconId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionName = table.Column<string>(type: "TEXT", nullable: true),
                    BeaconId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                    table.ForeignKey(
                        name: "FK_Regions_Beacons_BeaconId",
                        column: x => x.BeaconId,
                        principalTable: "Beacons",
                        principalColumn: "BeaconId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[] { 1, "ABC" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[] { 2, "XYZ" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[] { 3, "KLM" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[] { 4, "UVW" });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId" },
                values: new object[] { 8, 4 });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 5, 3, 2m, "", "Nectarines", "12" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 16, 8, 3m, "", "US Weekly", "2" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 15, 7, 15m, "", "Organix Conditioner", "25" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 14, 7, 9m, "", "Scotch Bite sponges", "13" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 13, 6, 16m, "", "Dial soap", "25" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 12, 6, 15m, "", "Hi-c Fruit punch", "13" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 11, 5, 7m, "", "Milk", "10" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 10, 5, 20m, "", "Cranberry cocktail", "21" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 17, 8, 12m, "", "Cococola", "13" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 3, 2, 12m, "", "Fresh express letuce", "4" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 4, 2, 8m, "", "Spinach", "7" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 18, 1, 25m, "", "Laptop", "250" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 2, 1, 6m, "", "Oranges", "9" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 1, 1, 12m, "", "Pineapple", "6" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 9, 4, 8m, "", "Gastorade", "22" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 8, 4, 4m, "", "Brach's Jelly beans", "20" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 7, 3, 7m, "", "Croissants", "12" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 6, 3, 5m, "", "Fresh seedless whole watermelon", "11" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 19, 1, 10m, "", "Head phones", "120" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "BeaconId", "RegionName" },
                values: new object[] { 1, 1, "Grocery" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "BeaconId", "RegionName" },
                values: new object[] { 2, 2, "Dairy" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "BeaconId", "RegionName" },
                values: new object[] { 4, 4, "Life style" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "BeaconId", "RegionName" },
                values: new object[] { 5, 5, "Kitchen Appliances" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "BeaconId", "RegionName" },
                values: new object[] { 6, 6, "Kids Wear" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "BeaconId", "RegionName" },
                values: new object[] { 3, 3, "Fresh Produce" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "BeaconId", "RegionName" },
                values: new object[] { 7, 7, "Men's Wear" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "BeaconId", "RegionName" },
                values: new object[] { 8, 8, "Women's Wear" });

            migrationBuilder.CreateIndex(
                name: "IX_Beacons_ManufacturerId",
                table: "Beacons",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_BeaconId",
                table: "Discounts",
                column: "BeaconId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_BeaconId",
                table: "Regions",
                column: "BeaconId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Beacons");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
