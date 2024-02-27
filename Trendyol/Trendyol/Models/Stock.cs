using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Models;

public class Stock
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey("Product")]
    public string ProductId { get; set; }

    public int ProductCount { get; set; }
}