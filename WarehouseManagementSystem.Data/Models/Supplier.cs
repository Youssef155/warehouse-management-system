using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }

    public ICollection<SupplyOrder> SupplyOrders { get; set; } = new List<SupplyOrder>();
}
