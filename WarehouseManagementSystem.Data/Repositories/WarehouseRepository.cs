using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.DTOs;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class WarehouseRepository
    {
        private readonly WMSDbContext _context;

        public WarehouseRepository(WMSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WarehouseDto> GetAll()
        {
            return _context.Warehouses
                .Select(w => new WarehouseDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Address = w.Address,
                    Manager = w.Manager
                }).ToList();
        }
    }
}
