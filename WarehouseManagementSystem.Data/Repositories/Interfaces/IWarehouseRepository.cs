using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.DTOs;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Data.Repositories.Interfaces
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        IEnumerable<WarehouseDto> GetAll();
    }
}
