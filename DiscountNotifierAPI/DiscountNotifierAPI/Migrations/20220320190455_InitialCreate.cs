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
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Beacons",
                columns: table => new
                {
                    BeaconId = table.Column<string>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Beacons_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
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
                    BeaconId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Beacons_BeaconId",
                        column: x => x.BeaconId,
                        principalTable: "Beacons",
                        principalColumn: "BeaconId",
                        onDelete: ReferentialAction.Restrict);
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
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[] { 1, "Grocery" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[] { 2, "Dairy" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[] { 3, "Fresh Produce" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[] { 4, "Life style" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[] { 5, "Kitchen Appliances" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[] { 6, "Kids' Wear" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[] { 7, "Men's Wear" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[] { 8, "Women's Wear" });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "ADB4F7B6-03DB-4E4D-A5C4-06BF06ED73FB", 2, 1 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "29BBD088-7DA0-400E-A8DD-60E0150C2D88", 2, 2 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "F281620A-3535-4CBB-8AF1-876C25A4D558", 1, 3 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "915BA882-EF04-4366-BB16-A75C86123F43", 1, 4 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "4A4BB6F2-9D48-420F-90D4-99D3438EFE27", 3, 5 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "42866756-090B-4AFF-9D0D-F76BA5E92DE7", 3, 6 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "55C1F308-9E48-4BD2-829B-9C000FF010BC", 4, 7 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "EDDB2708-10B0-4AF7-9DD1-B85F6316EDE3", 4, 8 });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 1, "ADB4F7B6-03DB-4E4D-A5C4-06BF06ED73FB", 12m, "", "Pineapple", "6" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 15, "55C1F308-9E48-4BD2-829B-9C000FF010BC", 15m, "", "Organix Conditioner", "25" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 14, "55C1F308-9E48-4BD2-829B-9C000FF010BC", 9m, "", "Scotch Bite sponges", "13" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 13, "42866756-090B-4AFF-9D0D-F76BA5E92DE7", 16m, "", "Dial soap", "25" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 12, "42866756-090B-4AFF-9D0D-F76BA5E92DE7", 15m, "", "Hi-c Fruit punch", "13" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 11, "4A4BB6F2-9D48-420F-90D4-99D3438EFE27", 7m, "", "Milk", "10" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 10, "4A4BB6F2-9D48-420F-90D4-99D3438EFE27", 20m, "", "Cranberry cocktail", "21" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 9, "915BA882-EF04-4366-BB16-A75C86123F43", 8m, "", "Gastorade", "22" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 16, "EDDB2708-10B0-4AF7-9DD1-B85F6316EDE3", 3m, "", "US Weekly", "2" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 8, "915BA882-EF04-4366-BB16-A75C86123F43", 4m, "", "Brach's Jelly beans", "20" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 6, "F281620A-3535-4CBB-8AF1-876C25A4D558", 5m, "", "Fresh seedless whole watermelon", "11" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 5, "F281620A-3535-4CBB-8AF1-876C25A4D558", 2m, "", "Nectarines", "12" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 4, "29BBD088-7DA0-400E-A8DD-60E0150C2D88", 8m, "", "Spinach", "7" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 3, "29BBD088-7DA0-400E-A8DD-60E0150C2D88", 12m, "", "Fresh express letuce", "4" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 19, "ADB4F7B6-03DB-4E4D-A5C4-06BF06ED73FB", 10m, "", "Head phones", "120" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 18, "ADB4F7B6-03DB-4E4D-A5C4-06BF06ED73FB", 25m, "", "Laptop", "250" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 2, "ADB4F7B6-03DB-4E4D-A5C4-06BF06ED73FB", 6m, "", "Oranges", "9" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 7, "F281620A-3535-4CBB-8AF1-876C25A4D558", 7m, "", "Croissants", "12" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 17, "EDDB2708-10B0-4AF7-9DD1-B85F6316EDE3", 12m, "", "Cococola", "13" });

            migrationBuilder.CreateIndex(
                name: "IX_Beacons_ManufacturerId",
                table: "Beacons",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Beacons_RegionId",
                table: "Beacons",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_BeaconId",
                table: "Discounts",
                column: "BeaconId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Beacons");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
