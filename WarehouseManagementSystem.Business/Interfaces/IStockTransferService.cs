using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Core.DTOs;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Business.Interfaces;


public interface IStockTransferService
{
    Task<IEnumerable<StockTransfer>> GetAllStockTransfersAsync();
    Task<StockTransfer> GetStockTransferByIdAsync(int id);
    Task<bool> TransferStockAsync(StockTransferDto transferDto);
}
