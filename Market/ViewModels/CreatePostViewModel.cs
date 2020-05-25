using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Market.ViewModels
{
    public class CreatePostViewModel 
    {
        [Required]
        [Range(5,100)]
        public string Title { get; set; }
        [Required]
        [Range(10,1000)]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
