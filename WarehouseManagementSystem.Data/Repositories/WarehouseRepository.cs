using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.DTOs;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        private readonly WMSDbContext _context;

        public WarehouseRepository(WMSDbContext context) : base(context) 
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
