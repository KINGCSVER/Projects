using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Models;

public class Order
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string TrackingId { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey("User")]
    public string UserId { get; set; }

    public User Users { get; set; }

    [ForeignKey("Products")]
    public string ProductId { get; set; }

    public string Product { get; set; }

    public int ProductsCount { get; set; }

    [Required]
    public int Status { get; set; }

    public DateTime Created { get; set; }
}
