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

    public IEnumerable<StockTransfer> GetAllStockTransfers() => _unitOfWork.StockTransfers.GetAll();

    public StockTransfer GetStockTransferById(int id) => _unitOfWork.StockTransfers.GetById(id);

    public void TransferStock(int fromWarehouseId, int toWarehouseId, int itemId, int quantity, DateTime transferDate)
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

        _unitOfWork.StockTransfers.Add(transfer);
        _unitOfWork.Save();
    }
}
