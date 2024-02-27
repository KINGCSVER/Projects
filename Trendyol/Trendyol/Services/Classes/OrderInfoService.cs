using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Context;
using Trendyol.Models;

namespace Trendyol.Services.Classes;

public class OrderInfoService
{
    private readonly TrendyolDbContext _context;

    public OrderInfoService(TrendyolDbContext context)
    {
        _context = context;
    }

/*    public Order OrderInfo()
    { 
    }*/
}