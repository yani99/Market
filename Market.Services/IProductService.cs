using Market.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services
{
    interface IProductService
    {
        Task<List<Product>> GetPaginatedResult(int currentPage, int pageSize = 8);
        int GetCount();
    }
}
