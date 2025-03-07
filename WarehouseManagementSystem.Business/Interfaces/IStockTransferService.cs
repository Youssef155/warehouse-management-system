using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface IStockTransferService
{
    Task<IEnumerable<StockTransfer>> GetAllStockTransfersAsync();
    Task<StockTransfer> GetStockTransferByIdAsync(int id);
    Task TransferStockAsync(int fromWarehouseId, int toWarehouseId, int itemId, int quantity, DateTime transferDate);
}
