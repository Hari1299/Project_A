using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name = "Executive Id")]
        public int ExecutiveId { get; set; }
        [Display(Name = "Date Time Of PickUp")]
        public DateTime DateTimeOfPickUp { get; set; }
        [Display(Name = "Weight Of Package")]
        [Required(ErrorMessage = "enter the weight of package")]

        public string WeightOfPackage { get; set; }

        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "enter city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Pincode cannot be empty!!")]
        public int PinCode { get; set; }

        [Required(ErrorMessage = "Enter your phone number!!")]
        [MaxLength(10, ErrorMessage = "should be only 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Should be a number!")]
        public string Phone { get; set; }
        public int Price { get; set; } = 500;

        public string DeliveryStatus { get; set; }
    }
}
