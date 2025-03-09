using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.Repositories.Interfaces;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly WMSDbContext _context;

        public SupplierRepository(WMSDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Supplier>> SearchByNameAsync(string name)
        {
            return await _context.Suppliers
                .Where(s  => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }
    }
}
