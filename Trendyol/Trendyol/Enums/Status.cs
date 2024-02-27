using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Enums;

public class StatusEnum
{
    public enum Status 
    {
        OrderPlaced = 1,
        ArrivedAtWarehouse,
        Sent,
        SmartCustomCheck,
        InFillial
    }
}
