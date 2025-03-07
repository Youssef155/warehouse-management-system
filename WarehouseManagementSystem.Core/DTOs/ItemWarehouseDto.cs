using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Core.DTOs;

public class ItemWarehouseDto
{
    public string ItemName { get; set; }
    public string WarehouseName { get; set; }
    public int Quantity { get; set; }
    public string ItemCode { get; set; }
    public string ItemUnit { get; set; }
}
