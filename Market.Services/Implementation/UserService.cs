using Market.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly MarketDBContext _context;

        public UserService(MarketDBContext context)
        {
            _context = context;
        }

        public Task<int> GetOrdersCountAsync(string id)
        {
            return _context.Order.CountAsync(p => p.UserId == id);
        }

        public List<Order> GetAllOrders(string id)
        {
           return _context.Order.Where(ord => ord.UserId == id).ToList();
        }
    }
}
