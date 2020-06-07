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

        public int Create(Product entity)
        {
            _context.Product.Add(entity);
            _context.SaveChanges();
            return entity.Id; //check
            
        }
        
        public List<Product> GetAll(int id)
        {
            return _context.Product.ToList();
        }

        public Product GetById(int id)
        {
            return  _context.Product.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product Update(Product entity)
        {
            var product = _context.Product.Where(p => p.Id == entity.Id).FirstOrDefault();
            _context.Entry(product).CurrentValues.SetValues(entity);    
            _context.SaveChanges();
            return product;
        }
        public bool Delete(int id)
        {
            bool status;
            try
            {
                var prodItem = _context.Product.Where(p => p.Id == id).FirstOrDefault();
                if (prodItem != null)
                {
                    _context.Product.Remove(prodItem);
                    _context.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }
        public int GetCount()
        {
            return _context.Product.Count();
        }

        public List<Product> GetPaginatedResult(int currentPage, int pageSize = 8)
        {
            return _context.Product
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
