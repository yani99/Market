using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Market.ViewModels
{
    public class DetailAccountViewModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public decimal Balance { get; set; }

        [Display(Name = "Full name")]
        public string FullName
        {
           get { return FirstName + LastName; }
        }
    }
}
