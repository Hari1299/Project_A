using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeliveryBookingSystem.Models
{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> customer { get; set; }
        public DbSet<DeliveryExecutive> deliveryexecutive { get; set; }
        public DbSet<Booking> booking { get; set; }
    }
}
