namespace WarehouseManagementSystem.Core.DTOs
{
    public class ItemUnitDto
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal ConversionFactor { get; set; } // Example: 1 Box = 10 Kg
    }

}