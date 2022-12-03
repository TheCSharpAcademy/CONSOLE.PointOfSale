using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KebPOS.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    [Precision(18, 2)]
    public decimal TotalPrice { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
