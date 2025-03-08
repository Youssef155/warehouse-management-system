namespace WarehouseManagementSystem.Core.DTOs;

public class StockTransferDto
{
    public int ItemId { get; set; }
    public int SourceWarehouseId { get; set; }
    public int DestinationWarehouseId { get; set; }
    public int TransferQuantity { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime TransferDate { get; set; }
    public List<StockTransferItemDto> Items { get; set; } = new List<StockTransferItemDto>();
}
