using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class SupplyOrderDetail : BaseEntity
{
    public int SupplyOrderId { get; set; }
    public SupplyOrder SupplyOrder { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    public int Quantity { get; set; }
    public DateTime ProductionDate { get; set; }
    public int ShelfLifeDays { get; set; } // Expiry Calculation
}
