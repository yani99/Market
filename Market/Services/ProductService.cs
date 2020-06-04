using Market.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IProductService
    {
        List<Product> GetPaginatedResult(int currentPage, int pageSize = 5);
        int GetCount();
    }
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

        public  List<Product> GetPaginatedResult(int currentPage, int pageSize = 5)
        {
            return _context.Product
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(d => d.Id)
                .ToList();
        }
    }
}
