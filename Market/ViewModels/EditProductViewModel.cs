using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Market.ViewModels
{
    public class EditProductViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
