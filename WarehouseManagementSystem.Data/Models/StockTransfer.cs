using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class StockTransfer : BaseEntity
{
    public int FromWarehouseId { get; set; }
    public Warehouse FromWarehouse { get; set; }

    public int ToWarehouseId { get; set; }
    public Warehouse ToWarehouse { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    public int Quantity { get; set; }
    public DateTime TransferDate { get; set; }
}

