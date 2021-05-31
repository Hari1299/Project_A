using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryBookingSystem.Models;
using Microsoft.Extensions.Logging;

namespace DeliveryBookingSystem.Services
{
    public class CustomerManager:IRepo<Customer>
    {
        public CustomerContext _context;
        public ILogger<CustomerManager> _logger;
        public CustomerManager(CustomerContext context, ILogger<CustomerManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Customer t)
        {
            try
            {
                _context.customer.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Customer Get(int id)
        {
            try
            {
                Customer customer = _context.customer.FirstOrDefault(a => a.CustomerId == id);
                return customer;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                if ((_context.customer) == null)
                    return null;
                return _context.customer.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;

        }


        public int Login(Customer t)
        {
             Customer obj = _context.customer.Where(i => i.UserName.Equals(t.UserName) && i.Password.Equals(t.Password)&& i.IsVerified.Equals("yes")).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.CustomerId;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }

        public void Update(int id, Customer t)
        {

            Customer customer = Get(id);
            if (customer != null)
            {
                customer.IsVerified = t.IsVerified;
            }
            _context.SaveChanges();

        }
    }
}
