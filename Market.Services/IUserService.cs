using Market.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IUserService
    {
         Task<int> GetOrdersCountAsync(string Id);
         List<Order> GetAllOrders(string Id);
    }
}
