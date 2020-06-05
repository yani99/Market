using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Market.ViewModels
{
    public class CreateProductViewModel
    {
        public string UserId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Product Picture")]
        public byte[] ProfilePicture { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int QualityId { get; set; }
        public List<SelectListItem> QualityList { get; set; }
    }
}
