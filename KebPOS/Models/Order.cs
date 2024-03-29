using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KebPOS.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    [Precision(18, 2)]
    public decimal TotalPrice { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
