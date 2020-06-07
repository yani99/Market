using Market.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Market.ViewModels
{
    public class PaginatedListViewModel 
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; } 
        public int PageSize { get; set; } = 6;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public List<Product> Data { get; set; }
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
    }
}
