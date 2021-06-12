using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystem.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Enter your Name!!")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Username cannot be empty!!")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Age cannot be empty!!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter your phone number!!")]
        [MaxLength(10, ErrorMessage = "should be only 10 number and not exceed")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Should be a number!!")]
        public string  Phone { get; set; }

        [Required(ErrorMessage = "Address cannot be empty!!")]
        public string Address { get; set; }

        [Required(ErrorMessage = " enter city!")]
        public string City { get; set; }

        [Required(ErrorMessage = " enter pincode!")]
        public int Pincode { get; set; }

        [Display(Name = " Verified")]
        public string IsVerified { get; set; }

    }
}
