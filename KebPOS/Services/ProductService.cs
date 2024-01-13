using KebPOS.DbContexts;
using KebPOS.Models;
using Spectre.Console;

namespace KebPOS.Services;

public class ProductService
{
    internal static void InsertProduct()
    {
        bool exit = false;
        bool addNewProduct = true;
        
        while (addNewProduct)
        {
            bool isDuplicate = true;
            bool nameValid = false;
            bool pricePos = false;
            bool priceValid = false;
            bool descriptionValid = false;
            int nameLenghtLimit = 20;
            int descriptionLengthLimit = 200;
            var product = new Product();
            product = new Product();

            
            while (!nameValid || isDuplicate)
            {
                Console.Clear();
                product.Name = AnsiConsole.Ask<string>("Product's name (20 char limit):");

                nameValid = Validation.CheckStringLength(product.Name, nameLenghtLimit);
                isDuplicate = Validation.CheckDuplicateProductName(product);

                if (!nameValid)
                {
                    Console.WriteLine($"The product name {product.Name} is over 20 characters.");
                }
                if (isDuplicate)
                {
                    Console.WriteLine($"There is already a product named {product.Name}.");
                }
                if (!nameValid || isDuplicate)
                {
                    Console.WriteLine("Press any key to continue. Or press b to go back");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.KeyChar.ToString().ToLower() == "b")
                    {
                        // Perform some action when 'b' is pressed
                        exit = true;
                        nameValid = true;
                        isDuplicate = false;
                    }
                }
            }
            if (exit)
            {
                addNewProduct = false;
            }
            else
            {

                while (!pricePos || !priceValid)
                {
                    Console.Clear();
                    product.Price = AnsiConsole.Ask<decimal>("Product's price:");

                    pricePos = Validation.CheckPrice(product.Price);
                    priceValid = Validation.CheckValid(product.Price);


                    if (!pricePos)
                    {
                        Console.WriteLine("Price can not be negative.");
                    }
                    if (!priceValid)
                    {
                        Console.WriteLine($"{product.Price} is not a valid entry");
                    }
                    if (!priceValid || !priceValid)
                    {
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }

                }
                while (!descriptionValid)
                {
                    Console.Clear();
                    product.Description = AnsiConsole.Ask<string>("Product's description (200 char limit):");
                    descriptionValid = Validation.CheckStringLength(product.Description, descriptionLengthLimit);
                    if (!descriptionValid)
                    {
                        Console.WriteLine("The product description is over 200 characters");
                        Console.ReadKey();
                    }
                }

                KebabController.AddProduct(product);
                addNewProduct = AnsiConsole.Confirm("Would you like to enter a new product?");
            }
        }
    }

    public static List<Product> GetProductsFromDatabase()
    {
        using var db = new KebabContext();
        var products = db.Products
            .ToList();
        return products;
    }
    public static List<Product> GetProducts()
    {
        var products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Yogurt Kebab",
                Description = """
                    The other name of this yummy Kebab is “good for you Kebab” the Kebab is made up of paneer, raisins, oats and creamy yogurt. 
                    This Kebab is a total combination of health and taste. The addition of extraordinary paneer simply enhances the taste of the Kebab. 
                    You can add other veggies also.
                """,
                Price = 3.49m
            },
            new Product()
            {
                Id = 2,
                Name = "Shish Kebab",
                Description = """
                    This Kebab is one among all the most popular and delicious Kebabs. 
                    The special part of this Kebab is that they are grilled on the skewer. 
                    Here the word shish means skewer. And the word Kebab stands for meat. 
                    This dish comes under the category of side dish. 
                    This dish is very famous in Turkey. 
                    Just imagine the taste of Turkish dish with an Indian tadka. 
                    These are most popular of all Kebabs. 
                    Steamed vegetables and salads are served along with these Kebabs.
                """,
                Price = 4.19m
            },
            new Product()
            {
                Id = 3,
                Name = "Doner Kebab",
                Description = """
                    Another name of this Kebab is rotating Kebab. 
                    And this wonderful name is given to this Kebab because it is made on a vertical rotating spit. 
                    This comes under the category of popular fast food loved by all. 
                    The Kebab is made of lamb’s meat. 
                    The special taste of Kebab is due to its cooking style. 
                    The Kebabs are cooked slowly so that the meat juice could spread its flavor.
                    """,
                Price = 3.39m
            },
            new Product()
            {
                Id = 4,
                Name = "Kathi Kebab",
                Description = """
                    Kathi Kebabs are very famous as they are made using tandoor. 
                    This is the most popular Indian dish made using tandoor. 
                    We all know the taste of tandoori chicken and the reason behind its scrumptious taste is tandoor. 
                    This Kebab is a very wonderful snack to have. 
                    The best way of having these yummy Kathi Kebabs is by rolling them in Kathi roll. 
                    You can add lots and lots of chutney on the roll so that the taste of Kebabs enhances your mood also.
                """,
                Price = 3.37m
            },
            new Product()
            {
                Id = 5,
                Name = "Chapli Kebab",
                Description = """
                    Chapli Kebabs are a very famous dish of Pakistani cuisine. 
                    This minced meat has a special taste. 
                    The Kebab is made using beef. 
                    This Pakistani dish with an Indian special tadka is all you need to have.
                """,
                Price = 4.33m
            },
            new Product()
            {
                Id = 6,
                Name = "Burrah Kebab",
                Description = """
                    Burrah Kebabs are also known as barrah Kebab. 
                    The Kebab is made up of beef and lots and lots of spices. 
                    This Kebab is very famous Kebab of Mughlai cuisine. 
                    This dish comes under the heavy meal category. 
                    It majorly includes larger pieces of meat. 
                    If you are also among the Mughlai cuisine lovers, then you can’t afford to miss such an amazing dish.
                """,
                Price = 4.36m
            },
            new Product()
            {
                Id = 7,
                Name = "Chelow Kebab",
                Description = """
                    This is an Irani dish with an Indian tadka. 
                    This is, in fact, national food of Iran. 
                    The dish is basic but yummy in taste. 
                    They are always served with buttered rice. 
                    Most of the people prefer doogh which is a yogurt drink with this Kebab. 
                    The dish comes under the category of the side dish, but the taste of the dish is very special.
                """,
                Price = 4.29m
            },
            new Product()
            {
                Id = 8,
                Name = "Testi Kebab",
                Description = """
                    The name of the Kebab is testi Kebab, and here the word testi means jug. 
                    Yes, the Kebab is served in a pot. 
                    You can use dough or foil to cover the pot. 
                    The pot is broken while eating. 
                    We all know how special the taste of “matke ka pani” is. 
                    Similarly, the taste of matka Kebab is very special.
                """,
                Price = 3.69m
            },
            new Product()
            {
                Id = 9,
                Name = "Dill Salmon Kebab",
                Description = """
                    Dill salmon Kebab is very special Kebab for all seafood lovers and especially for fish lovers. 
                    The dish is very yummy.
                """,
                Price = 3.99m
            },
            new Product()
            {
                Id = 10,
                Name = "Lamb Kebab",
                Description = """
                    Lamb Kebabs are very easy to make. 
                    What all you need to do is marinate the mince meat with all the spices. 
                    You can add egg also just to enhance the taste of Kebab.
                """,
                Price = 3.79m
            },
            new Product()
            {
                Id = 11,
                Name = "Cappuccino",
                Description = "A freshly pulled shot of espresso layered with steamed whole milk and thick rich foam to offer a luxurious velvety texture and complex aroma.",
                Price = 1.49m
            },
            new Product()
            {
                Id = 12,
                Name = "Red Bull",
                Description = "Red Bull is a utility drink to be taken against mental or physical weariness or exhaustion.",
                Price = 1.87m
            },
            new Product()
            {
                Id = 13,
                Name = "Coca Cola",
                Description = "Coca-Cola is a carbonated, sweetened soft drink and is the world's best-selling drink. A popular nickname for Coca-Cola is Coke.",
                Price = 0.93m
            },
            new Product()
            {
                Id = 14,
                Name = "Sprite",
                Description = "Crisp, refreshing and clean-tasting, Sprite is a lemon and lime-flavoured soft drink.",
                Price = 1.99m
            },
            new Product()
            {
                Id = 15,
                Name = "Bonaqua Sparkling",
                Description = "BonAqua is a high-quality drinking water.",
                Price = 1.24m
            }
        };
        return products;
    }
}
