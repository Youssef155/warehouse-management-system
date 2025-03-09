using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class StockItem : BaseEntity
{
    public int WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }

    public int ItemId { get; set; }
    public virtual Item Item { get; set; }

    public int Quantity { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}
