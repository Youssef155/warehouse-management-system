namespace WarehouseManagementSystem.Core.DTOs
{
    public class WithdrawalOrderItemDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
