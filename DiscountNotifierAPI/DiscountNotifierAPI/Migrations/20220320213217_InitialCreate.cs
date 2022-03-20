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
                values: new object[] { "adb4f7b6-03db-4e4d-a5c4-06bf06ed73fb", 2, 1 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "29bbd088-7da0-400e-a8dd-60e0150c2d88", 2, 2 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "f281620a-3535-4cbb-8af1-876c25a4d558", 1, 3 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "915ba882-ef04-4366-bb16-a75c86123f43", 1, 4 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "4a4bb6f2-9d48-420f-90d4-99d3438efe27", 3, 5 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "42866756-090b-4aff-9d0d-f76ba5e92de7", 3, 6 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "55c1f308-9e48-4bd2-829b-9c000ff010bc", 4, 7 });

            migrationBuilder.InsertData(
                table: "Beacons",
                columns: new[] { "BeaconId", "ManufacturerId", "RegionId" },
                values: new object[] { "eddb2708-10b0-4af7-9dd1-b85f6316ede3", 4, 8 });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 7, "adb4f7b6-03db-4e4d-a5c4-06bf06ed73fb", 7m, "", "Croissants", "12" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 15, "55c1f308-9e48-4bd2-829b-9c000ff010bc", 15m, "", "Organix Conditioner", "25" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 14, "55c1f308-9e48-4bd2-829b-9c000ff010bc", 9m, "", "Scotch Bite sponges", "13" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 13, "42866756-090b-4aff-9d0d-f76ba5e92de7", 16m, "", "Dial soap", "25" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 12, "42866756-090b-4aff-9d0d-f76ba5e92de7", 15m, "", "Hi-c Fruit punch", "13" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 10, "4a4bb6f2-9d48-420f-90d4-99d3438efe27", 20m, "", "Cranberry cocktail", "21" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 19, "915ba882-ef04-4366-bb16-a75c86123f43", 10m, "", "Head phones", "120" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 18, "915ba882-ef04-4366-bb16-a75c86123f43", 25m, "", "Laptop", "250" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 16, "eddb2708-10b0-4af7-9dd1-b85f6316ede3", 3m, "", "Pyjamas", "2" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 6, "f281620a-3535-4cbb-8af1-876c25a4d558", 5m, "", "Fresh seedless whole watermelon", "11" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 4, "f281620a-3535-4cbb-8af1-876c25a4d558", 8m, "", "Spinach", "7" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 3, "f281620a-3535-4cbb-8af1-876c25a4d558", 12m, "", "Fresh express letuce", "4" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 2, "f281620a-3535-4cbb-8af1-876c25a4d558", 6m, "", "Oranges", "9" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 1, "f281620a-3535-4cbb-8af1-876c25a4d558", 12m, "", "Pineapple", "6" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 11, "29bbd088-7da0-400e-a8dd-60e0150c2d88", 7m, "", "Milk", "10" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 9, "adb4f7b6-03db-4e4d-a5c4-06bf06ed73fb", 8m, "", "Gastorade", "22" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 8, "adb4f7b6-03db-4e4d-a5c4-06bf06ed73fb", 4m, "", "Brach's Jelly beans", "20" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 5, "f281620a-3535-4cbb-8af1-876c25a4d558", 2m, "", "Nectarines", "12" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeaconId", "DiscountPercentage", "ImageUrl", "OfferText", "OriginalPrice" },
                values: new object[] { 17, "eddb2708-10b0-4af7-9dd1-b85f6316ede3", 12m, "", "Makeup", "13" });

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
