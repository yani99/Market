using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface ICreatePostService
    {
        void CreatePost(string title, string description, decimal price, int quantity,string userId);
    }
}
