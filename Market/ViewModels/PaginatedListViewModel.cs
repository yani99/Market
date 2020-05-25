using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.ViewModels
{
    public class PaginatedListViewModel<T> : List<T> 
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        private PaginatedListViewModel(List<T> items , int pageIndex , int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(items.Count / (double)pageSize);
            this.AddRange(items);
        }
        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static PaginatedListViewModel<T> CreateAsync(IEnumerable<T> source , int pageIndex , int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedListViewModel<T>(items, pageIndex, pageSize);
        }
    }
}
