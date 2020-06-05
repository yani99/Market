using Market.DAL.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> GetCurrentOrdersCount(string Id)
        {
            return await _context.Order.CountAsync(p => p.UserId == Id);
        }
    }
}
