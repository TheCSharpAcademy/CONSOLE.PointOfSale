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
        CloseApplication
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
}
