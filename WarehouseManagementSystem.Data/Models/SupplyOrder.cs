using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class SupplyOrder : BaseEntity
{
    public int WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }

    public int SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }

    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }

    public virtual ICollection<SupplyOrderDetail> SupplyOrderDetails { get; set; } = new List<SupplyOrderDetail>();
}
