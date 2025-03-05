using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class WithdrawalOrder : BaseEntity
{
    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }

    public ICollection<WithdrawalOrderDetail> WithdrawalOrderDetails { get; set; } = new List<WithdrawalOrderDetail>();
}
