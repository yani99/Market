using Market.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IUserService
    {
        Task<int> GetCurrentOrdersCount(string Id);
    }
}
