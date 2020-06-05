using Market.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly MarketDBContext _context;
        public ProductService(MarketDBContext context)
        {
            _context = context;
        }

        public int GetCount()
        {
            return _context.Product.Count();
        }

        public async Task<List<Product>> GetPaginatedResult(int currentPage, int pageSize = 8)
        {
            return await _context.Product
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
