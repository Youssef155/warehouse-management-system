using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class StockTransferDetail : BaseEntity
{
    public int StockTransferId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    // Navigation Properties
    public StockTransfer StockTransfer { get; set; }
    public Item Item { get; set; }
}
