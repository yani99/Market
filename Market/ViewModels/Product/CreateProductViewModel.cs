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
        [Range(1,9999999.99,ErrorMessage ="The {0} must be between {1} and {2}")]
        public decimal Price { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Product Picture")]
        public byte[] ProfilePicture { get; set; }
        [Required]
        [Range(1,100,ErrorMessage ="The {0} must be between {1} and {2}")]
        public int Quantity { get; set; }
        public int QualityId { get; set; }
        public List<SelectListItem> QualityList { get; set; }
    }
}
