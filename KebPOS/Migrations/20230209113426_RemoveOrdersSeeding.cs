using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KebPOS.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrdersSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "    The other name of this yummy Kebab is “good for you Kebab” the Kebab is made up of paneer, raisins, oats and creamy yogurt. \n    This Kebab is a total combination of health and taste. The addition of extraordinary paneer simply enhances the taste of the Kebab. \n    You can add other veggies also.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "    This Kebab is one among all the most popular and delicious Kebabs. \n    The special part of this Kebab is that they are grilled on the skewer. \n    Here the word shish means skewer. And the word Kebab stands for meat. \n    This dish comes under the category of side dish. \n    This dish is very famous in Turkey. \n    Just imagine the taste of Turkish dish with an Indian tadka. \n    These are most popular of all Kebabs. \n    Steamed vegetables and salads are served along with these Kebabs.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Another name of this Kebab is rotating Kebab. \nAnd this wonderful name is given to this Kebab because it is made on a vertical rotating spit. \nThis comes under the category of popular fast food loved by all. \nThe Kebab is made of lamb’s meat. \nThe special taste of Kebab is due to its cooking style. \nThe Kebabs are cooked slowly so that the meat juice could spread its flavor.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "    Kathi Kebabs are very famous as they are made using tandoor. \n    This is the most popular Indian dish made using tandoor. \n    We all know the taste of tandoori chicken and the reason behind its scrumptious taste is tandoor. \n    This Kebab is a very wonderful snack to have. \n    The best way of having these yummy Kathi Kebabs is by rolling them in Kathi roll. \n    You can add lots and lots of chutney on the roll so that the taste of Kebabs enhances your mood also.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "    Chapli Kebabs are a very famous dish of Pakistani cuisine. \n    This minced meat has a special taste. \n    The Kebab is made using beef. \n    This Pakistani dish with an Indian special tadka is all you need to have.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "    Burrah Kebabs are also known as barrah Kebab. \n    The Kebab is made up of beef and lots and lots of spices. \n    This Kebab is very famous Kebab of Mughlai cuisine. \n    This dish comes under the heavy meal category. \n    It majorly includes larger pieces of meat. \n    If you are also among the Mughlai cuisine lovers, then you can’t afford to miss such an amazing dish.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "    This is an Irani dish with an Indian tadka. \n    This is, in fact, national food of Iran. \n    The dish is basic but yummy in taste. \n    They are always served with buttered rice. \n    Most of the people prefer doogh which is a yogurt drink with this Kebab. \n    The dish comes under the category of the side dish, but the taste of the dish is very special.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "    The name of the Kebab is testi Kebab, and here the word testi means jug. \n    Yes, the Kebab is served in a pot. \n    You can use dough or foil to cover the pot. \n    The pot is broken while eating. \n    We all know how special the taste of “matke ka pani” is. \n    Similarly, the taste of matka Kebab is very special.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "    Dill salmon Kebab is very special Kebab for all seafood lovers and especially for fish lovers. \n    The dish is very yummy.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "    Lamb Kebabs are very easy to make. \n    What all you need to do is marinate the mince meat with all the spices. \n    You can add egg also just to enhance the taste of Kebab.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 6, 34, 3, 450, DateTimeKind.Utc).AddTicks(638), 11.81m },
                    { 2, new DateTime(2022, 11, 27, 6, 38, 3, 450, DateTimeKind.Utc).AddTicks(645), 6.86m },
                    { 3, new DateTime(2022, 11, 27, 6, 43, 3, 450, DateTimeKind.Utc).AddTicks(655), 7.75m }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "    The other name of this yummy Kebab is “good for you Kebab” the Kebab is made up of paneer, raisins, oats and creamy yogurt. \r\n    This Kebab is a total combination of health and taste. The addition of extraordinary paneer simply enhances the taste of the Kebab. \r\n    You can add other veggies also.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "    This Kebab is one among all the most popular and delicious Kebabs. \r\n    The special part of this Kebab is that they are grilled on the skewer. \r\n    Here the word shish means skewer. And the word Kebab stands for meat. \r\n    This dish comes under the category of side dish. \r\n    This dish is very famous in Turkey. \r\n    Just imagine the taste of Turkish dish with an Indian tadka. \r\n    These are most popular of all Kebabs. \r\n    Steamed vegetables and salads are served along with these Kebabs.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Another name of this Kebab is rotating Kebab. \r\nAnd this wonderful name is given to this Kebab because it is made on a vertical rotating spit. \r\nThis comes under the category of popular fast food loved by all. \r\nThe Kebab is made of lamb’s meat. \r\nThe special taste of Kebab is due to its cooking style. \r\nThe Kebabs are cooked slowly so that the meat juice could spread its flavor.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "    Kathi Kebabs are very famous as they are made using tandoor. \r\n    This is the most popular Indian dish made using tandoor. \r\n    We all know the taste of tandoori chicken and the reason behind its scrumptious taste is tandoor. \r\n    This Kebab is a very wonderful snack to have. \r\n    The best way of having these yummy Kathi Kebabs is by rolling them in Kathi roll. \r\n    You can add lots and lots of chutney on the roll so that the taste of Kebabs enhances your mood also.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "    Chapli Kebabs are a very famous dish of Pakistani cuisine. \r\n    This minced meat has a special taste. \r\n    The Kebab is made using beef. \r\n    This Pakistani dish with an Indian special tadka is all you need to have.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "    Burrah Kebabs are also known as barrah Kebab. \r\n    The Kebab is made up of beef and lots and lots of spices. \r\n    This Kebab is very famous Kebab of Mughlai cuisine. \r\n    This dish comes under the heavy meal category. \r\n    It majorly includes larger pieces of meat. \r\n    If you are also among the Mughlai cuisine lovers, then you can’t afford to miss such an amazing dish.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "    This is an Irani dish with an Indian tadka. \r\n    This is, in fact, national food of Iran. \r\n    The dish is basic but yummy in taste. \r\n    They are always served with buttered rice. \r\n    Most of the people prefer doogh which is a yogurt drink with this Kebab. \r\n    The dish comes under the category of the side dish, but the taste of the dish is very special.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "    The name of the Kebab is testi Kebab, and here the word testi means jug. \r\n    Yes, the Kebab is served in a pot. \r\n    You can use dough or foil to cover the pot. \r\n    The pot is broken while eating. \r\n    We all know how special the taste of “matke ka pani” is. \r\n    Similarly, the taste of matka Kebab is very special.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "    Dill salmon Kebab is very special Kebab for all seafood lovers and especially for fish lovers. \r\n    The dish is very yummy.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "    Lamb Kebabs are very easy to make. \r\n    What all you need to do is marinate the mince meat with all the spices. \r\n    You can add egg also just to enhance the taste of Kebab.");

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
        }
    }
}
