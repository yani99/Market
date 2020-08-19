using Market.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services
{
   public interface IProductService
    {
        public List<Product> GetAll(int id);
        public Product GetById(int id);
        public int Create(Product entity);
        public Product Update(Product entity);
        public bool Delete(int id);

        List<Product> GetPaginatedResult(int currentPage, int pageSize = 8);
        int GetCount();
        List<SelectListItem> QualitySelectList();
    }
}
