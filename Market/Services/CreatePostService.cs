using Market.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Services
{
    public class CreatePostService : ICreatePostService
    {
        private MarketDBContext dbContext;
        public CreatePostService(MarketDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreatePost(string title, string description, decimal price,int quantity,string userId)
        {
            var product = new Product
            {
                Title = title,
                Description = description,
                Price = price,
                Quantity = quantity,
                UserId=userId,
            };
            dbContext.Add(product);
            dbContext.SaveChanges();
        }
    }
}
