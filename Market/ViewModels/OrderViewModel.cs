using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Market.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Amount
        { get { return Price * Quantity; } }

        public string UserId { get; set; }

        public int ShipperId { get; set; }
        public List<SelectListItem> ShipperList { get; set; }
    }
}
