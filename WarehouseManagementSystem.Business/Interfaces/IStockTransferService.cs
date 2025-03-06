using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface IStockTransferService
{
    IEnumerable<StockTransfer> GetAllStockTransfers();
    StockTransfer GetStockTransferById(int id);
    void TransferStock(int fromWarehouseId, int toWarehouseId, int itemId, int quantity, DateTime transferDate);
}
