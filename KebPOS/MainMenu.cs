using KebPOS.Models;

namespace KebPOS;

public class MainMenu
{
    private readonly KebabController _kebabController = new();
    private readonly UserInput _userInput = new();
    internal void InitializeMenu()
    {
        bool closeMenu = false;

        while (closeMenu == false)
        {
            Console.WriteLine("\nWelcome to KebPOS");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("Type 1 to add new order");
            Console.WriteLine("Type 2 to view orders");
            Console.WriteLine("Type 3 to view order details");
            Console.WriteLine("\nType 0 to Close Application.");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    closeMenu = true;
                    break;
                case "1":
                    AddNewOrder();
                    break;
                case "2":
                    ViewOrders(_kebabController.GetOrders());
                    break;
                case "3":
                    ViewOrderDetails();
                    break;
                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 1 - 3.\n");
                    break;
            }
        }
    }

    private void AddNewOrder()
    {
        Dictionary<int, int> productQuantityPairs = new();

        decimal totalPrice = 0;

        string answer;
        do
        {
            var products = _kebabController.GetProducts();

            DisplayProducts(products);

            var id = GetSelectedProduct(products);
            var quantity = GetProductQuantity();

            if (productQuantityPairs.ContainsKey(id))
            {
                productQuantityPairs[id] += quantity;
                totalPrice += (GetPrice(id, products) * quantity);
            }
            else
            {
                productQuantityPairs[id] = quantity;
                totalPrice += (GetPrice(id, products) * quantity);
            }

            Console.Write("Do you want to add another product to your order? yes/no: ");
            answer = _userInput.GetValidAnswer();
        } while (answer != "n" && answer != "no");

        var order = CreateNewOrder(totalPrice);

        var orderProductsList = GetOrderProductList(productQuantityPairs, order);

        _kebabController.AddOrders(orderProductsList);
    }

    private int GetProductQuantity()
    {
        Console.Write("How many do you want to add to your order?: ");
        var quantity = _userInput.GetQuantity();

        return quantity;
    }

    private Order CreateNewOrder(decimal totalPrice)
    {
        return new Order
        {
            OrderDate = DateTime.Now,
            TotalPrice = totalPrice,
        };
    }

    private List<OrderProduct> GetOrderProductList(Dictionary<int, int> productQuantityPairs, Order order)
    {
        List<OrderProduct> orderProductsList = new();

        foreach (var productId in productQuantityPairs.Keys)
        {
            var orderProduct = new OrderProduct
            {
                ProductId = productId,
                Order = order,
                Quantity = productQuantityPairs[productId]
            };

            orderProductsList.Add(orderProduct);
        }

        return orderProductsList;
    }

    private decimal GetPrice(int id, List<Product> products)
    {
        var price = products.First(p => p.Id == id).Price;

        return price;
    }

    private int GetSelectedProduct(List<Product> products)
    {
        Console.Write("Select a product by Id to add to cart: ");
        var choice = _userInput.GetId();

        var id = int.Parse(choice);

        while (!products.Exists(p => p.Id == id))
        {
            Console.Write("Select a product by Id to add to cart: ");
            choice = _userInput.GetId();

            id = int.Parse(choice);
        }

        return id;
    }

    private void DisplayProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}\n{product.Name}\n{product.Description}\n{product.Price}\n\n");
        }
    }

    private void ViewOrders(List<Order> orders)
    {
        string output = $"+----- Current Orders ({orders.Count}) -----+\n";
        foreach (var order in orders)
        {
            output += $"[#{orders.IndexOf(order) + 1}] {order.OrderDate} - ${order.TotalPrice}\n";
        }
        Console.WriteLine(output);
    }

    private void ViewOrderDetails()
    {
        List<Order> orders = _kebabController.GetOrders();

        ViewOrders(orders);

        Console.Write("\nSelect an order by its index to view the order details: ");
        var indexString = _userInput.GetId();
        int index = int.Parse(indexString);

        Order order = new();
        try
        {
            index = orders[index-1].Id;
            order = orders.FirstOrDefault(x => x.Id == index);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"Order with the index '{index}' does not exist. Press any key to try again...");
            Console.ReadLine();
            ViewOrderDetails();
        }

        string output = $"\n+----- Viewing Order -----+\n";
        output += $"[#{index}] {order.OrderDate} - ${order.TotalPrice}\n";
        foreach (var item in order.OrderProducts)
        {
            output += $"\t{item.Product.Name} - ${item.Product.Price}\n";
        }

        Console.WriteLine(output);

        Console.Write("Do you want to view another orders, order details? yes/no: ");
        string answer = _userInput.GetValidAnswer();

        if (answer == "y" || answer == "yes")
        {
            ViewOrderDetails();
        }
    }
}