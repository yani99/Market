using Market.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly MarketDBContext _context;
        private readonly DbSet<Order> _table;

        public OrderService(MarketDBContext context)
        {
            _context = context;
            _table = context.Order;
        }

        public Order GetById(int id)
        =>  _table.FirstOrDefault(ord => ord.Id == id);

        public EntityEntry<Order> Add(Order entity)
        {
             var order =_table.Add(entity);
             _context.SaveChanges();
            return order;
        }


        public bool Remove(int id)
        {
            var entity = GetById(id);
            if (entity == null) { return false; }
            _table.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Order entity)
        {
            var order = GetById(entity.Id);
            if (order == null) { return false; }
            _context.Entry(order).CurrentValues.SetValues(entity);
            return _context.SaveChanges() > 0;
        }

        public List<Shipper> GetAllShippers()
        =>  _context.Shipper.ToList();
    }
}