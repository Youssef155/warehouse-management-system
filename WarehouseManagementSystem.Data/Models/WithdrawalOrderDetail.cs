using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Models;

public class WithdrawalOrderDetail : BaseEntity
{
    public int WithdrawalOrderId { get; set; }
    public WithdrawalOrder WithdrawalOrder { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    public int Quantity { get; set; }
}

