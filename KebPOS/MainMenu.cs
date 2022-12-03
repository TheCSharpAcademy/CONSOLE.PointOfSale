using KebPOS.Models;
using KebPOS.UI; 
using KebPOS.Services; 
namespace KebPOS;

public class MainMenu
{
    internal void InitializeMenu()
    {
        MainUi ui = new MainUi(); 
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
                     //Test Adding data to table
                     //ui.DisplayTable(ProductService.GetProducts());                   
                    //AddNewOrder();
                    break;
                case "2":
                    ViewOrders();
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
        throw new NotImplementedException();
    }

    private void ViewOrders()
    {
        throw new NotImplementedException();
    }

    private void ViewOrderDetails()
    {
        throw new NotImplementedException();
    }
}
