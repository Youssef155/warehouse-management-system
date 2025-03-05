using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class Item : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string MeasurementUnit { get; set; }

    public ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();
}
