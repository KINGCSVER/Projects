using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Models;

public class Product
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required, MaxLength(30), RegularExpression("^[A-Z][a-z]+$")]
    public string Name { get; set; }

    [Required, MaxLength(255)]
    public string Description { get; set; }

    [Required]
    public int Count { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public byte[] Image { get; set; }
}