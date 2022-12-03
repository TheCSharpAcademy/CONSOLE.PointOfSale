using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KebPOS.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }

    [Precision(18, 2)]
    public decimal Price { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
}
