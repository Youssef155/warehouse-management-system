using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.DTOs;

namespace WarehouseManagementSystem.Data.Repositories.Interfaces
{
    public interface IWarehouseRepository
    {
        IEnumerable<WarehouseDto> GetAll();
    }
}
