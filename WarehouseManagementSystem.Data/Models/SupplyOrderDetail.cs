using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class SupplyOrderDetail : BaseEntity
{
    public int SupplyOrderId { get; set; }
    public virtual SupplyOrder SupplyOrder { get; set; }

    public int ItemId { get; set; }
    public virtual Item Item { get; set; }

    public int Quantity { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}
