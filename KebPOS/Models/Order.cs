namespace KebPOS.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<Product> Items { get; set; }
    public decimal TotalPrice { get; set; }
}
