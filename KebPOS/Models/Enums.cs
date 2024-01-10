namespace KebPOS.Models;

internal static class Enums
{
    public enum MainMenuSelections
    {
        NewOrder,
        ViewOrders,
        ViewOrderDetails,
        DeleteOrder,
        ManageProducts,
        CloseApplication,
        ViewReports
    }

    public enum ManageProductsSelections
    {
        ViewProducts,
        ViewProductDetails,
        AddProduct,
        UpdateProduct,
        DeleteProduct,
        ReturnToMainMenu
    }

    public enum ViewReportsSelections
    {
        SalesPerMonth,
        SalesPerYear,
        SalesPerDay,
        SalesPerWeek,
        ReturnToMainMenu
    }
}
