using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class Warehouse : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Manager { get; set; }

    public ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();
}
