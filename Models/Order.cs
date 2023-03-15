using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_mitch921.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }

        [Required(ErrorMessage ="Name is a required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number is a required field")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone Number must be in the format xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Address is a required field")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage="Address Line 1 is a required field")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        
        [Required(ErrorMessage = "City is a required field")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is a required field")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is a required field")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zipcode must be in the format xxxxx")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Country is a required field")]
        public string Country { get; set; }
    }
}
