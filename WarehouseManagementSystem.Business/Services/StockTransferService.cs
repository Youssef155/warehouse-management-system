using System;
using System.Collections.Generic;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Business.Services;



public class StockTransferService : IStockTransferService
{
    private readonly IUnitOfWork _unitOfWork;

    public StockTransferService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<StockTransfer>> GetAllStockTransfersAsync() => 
        await _unitOfWork.StockTransfers.GetAllAsync();

    public async Task<StockTransfer> GetStockTransferByIdAsync(int id) => 
        await _unitOfWork.StockTransfers.GetByIdAsync(id);

    public async Task TransferStockAsync(int fromWarehouseId, int toWarehouseId, int itemId, int quantity, DateTime transferDate)
    {
        if (fromWarehouseId == toWarehouseId)
            throw new ArgumentException("Cannot transfer stock to the same warehouse.");

        var transfer = new StockTransfer
        {
            FromWarehouseId = fromWarehouseId,
            ToWarehouseId = toWarehouseId,
            ItemId = itemId,
            Quantity = quantity,
            TransferDate = transferDate
        };

        await _unitOfWork.StockTransfers.AddAsync(transfer);
        await _unitOfWork.SaveAsync();
    }
}
