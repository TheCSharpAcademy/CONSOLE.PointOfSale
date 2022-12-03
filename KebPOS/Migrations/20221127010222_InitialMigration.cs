using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KebPOS.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 1, 2, 22, 751, DateTimeKind.Utc).AddTicks(3162), 11.81m },
                    { 2, new DateTime(2022, 11, 27, 1, 6, 22, 751, DateTimeKind.Utc).AddTicks(3165), 6.86m },
                    { 3, new DateTime(2022, 11, 27, 1, 11, 22, 751, DateTimeKind.Utc).AddTicks(3172), 7.75m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "    The other name of this yummy Kebab is “good for you Kebab” the Kebab is made up of paneer, raisins, oats and creamy yogurt. \r\n    This Kebab is a total combination of health and taste. The addition of extraordinary paneer simply enhances the taste of the Kebab. \r\n    You can add other veggies also.", "Yogurt Kebab", 3.49m },
                    { 2, "    This Kebab is one among all the most popular and delicious Kebabs. \r\n    The special part of this Kebab is that they are grilled on the skewer. \r\n    Here the word shish means skewer. And the word Kebab stands for meat. \r\n    This dish comes under the category of side dish. \r\n    This dish is very famous in Turkey. \r\n    Just imagine the taste of Turkish dish with an Indian tadka. \r\n    These are most popular of all Kebabs. \r\n    Steamed vegetables and salads are served along with these Kebabs.", "Shish Kebab", 4.19m },
                    { 3, "Another name of this Kebab is rotating Kebab. \r\nAnd this wonderful name is given to this Kebab because it is made on a vertical rotating spit. \r\nThis comes under the category of popular fast food loved by all. \r\nThe Kebab is made of lamb’s meat. \r\nThe special taste of Kebab is due to its cooking style. \r\nThe Kebabs are cooked slowly so that the meat juice could spread its flavor.", "Doner Kebab", 3.39m },
                    { 4, "    Kathi Kebabs are very famous as they are made using tandoor. \r\n    This is the most popular Indian dish made using tandoor. \r\n    We all know the taste of tandoori chicken and the reason behind its scrumptious taste is tandoor. \r\n    This Kebab is a very wonderful snack to have. \r\n    The best way of having these yummy Kathi Kebabs is by rolling them in Kathi roll. \r\n    You can add lots and lots of chutney on the roll so that the taste of Kebabs enhances your mood also.", "Kathi Kebab", 3.37m },
                    { 5, "    Chapli Kebabs are a very famous dish of Pakistani cuisine. \r\n    This minced meat has a special taste. \r\n    The Kebab is made using beef. \r\n    This Pakistani dish with an Indian special tadka is all you need to have.", "Chapli Kebab", 4.33m },
                    { 6, "    Burrah Kebabs are also known as barrah Kebab. \r\n    The Kebab is made up of beef and lots and lots of spices. \r\n    This Kebab is very famous Kebab of Mughlai cuisine. \r\n    This dish comes under the heavy meal category. \r\n    It majorly includes larger pieces of meat. \r\n    If you are also among the Mughlai cuisine lovers, then you can’t afford to miss such an amazing dish.", "Burrah Kebab", 4.36m },
                    { 7, "    This is an Irani dish with an Indian tadka. \r\n    This is, in fact, national food of Iran. \r\n    The dish is basic but yummy in taste. \r\n    They are always served with buttered rice. \r\n    Most of the people prefer doogh which is a yogurt drink with this Kebab. \r\n    The dish comes under the category of the side dish, but the taste of the dish is very special.", "Chelow Kebab", 4.29m },
                    { 8, "    The name of the Kebab is testi Kebab, and here the word testi means jug. \r\n    Yes, the Kebab is served in a pot. \r\n    You can use dough or foil to cover the pot. \r\n    The pot is broken while eating. \r\n    We all know how special the taste of “matke ka pani” is. \r\n    Similarly, the taste of matka Kebab is very special.", "Testi Kebab", 3.69m },
                    { 9, "    Dill salmon Kebab is very special Kebab for all seafood lovers and especially for fish lovers. \r\n    The dish is very yummy.", "Dill Salmon Kebab", 3.99m },
                    { 10, "    Lamb Kebabs are very easy to make. \r\n    What all you need to do is marinate the mince meat with all the spices. \r\n    You can add egg also just to enhance the taste of Kebab.", "Lamb Kebab", 3.79m },
                    { 11, "A freshly pulled shot of espresso layered with steamed whole milk and thick rich foam to offer a luxurious velvety texture and complex aroma.", "Cappuccino", 1.49m },
                    { 12, "Red Bull is a utility drink to be taken against mental or physical weariness or exhaustion.", "Red Bull", 1.87m },
                    { 13, "Coca-Cola is a carbonated, sweetened soft drink and is the world's best-selling drink. A popular nickname for Coca-Cola is Coke.", "Coca Cola", 0.93m },
                    { 14, "Crisp, refreshing and clean-tasting, Sprite is a lemon and lime-flavoured soft drink.", "Sprite", 1.99m },
                    { 15, "BonAqua is a high-quality drinking water.", "Bonaqua Sparkling", 1.24m }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 5 },
                    { 1, 9 },
                    { 2, 1 },
                    { 2, 4 },
                    { 3, 3 },
                    { 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
