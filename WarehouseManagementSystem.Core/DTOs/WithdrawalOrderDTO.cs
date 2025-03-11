namespace WarehouseManagementSystem.Core.DTOs
{
    public class WithdrawalOrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<WithdrawalOrderItemDTO> Items { get; set; }

        public WithdrawalOrderDTO()
        {
            Items = new List<WithdrawalOrderItemDTO>();
        }
    }
}
