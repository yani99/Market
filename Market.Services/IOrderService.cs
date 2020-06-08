using Market.DAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IOrderService
    {
        Order GetById(int id);
        EntityEntry<Order> Add(Order entity);
        bool Update(Order entity);
        bool Remove(int id);
        List<Shipper> GetAllShippers();
    }
}
