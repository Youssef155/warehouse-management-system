using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Core.DTOs
{
    public class SupplyOrderDto
    {
        public int OrderId { get; set; }
        public string OrderNumber {  get; set; }
        public DateTime OrderDate { get; set; }
        public string SupplierName { get; set; }
        public string WarehouseName { get; set; }
        public int SupplierId { get; set; }
        public int WarehouseId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string MeasurementUnit { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
