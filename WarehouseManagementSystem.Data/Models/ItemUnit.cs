using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class ItemUnit
{
    public int ItemId { get; set; }
    public int UnitId { get; set; }

    // Optional: If a conversion factor is needed (e.g., 1 Box = 10 Kg)
    public decimal ConversionFactor { get; set; }

    public Item Item { get; set; }
    public Unit Unit { get; set; }
}
