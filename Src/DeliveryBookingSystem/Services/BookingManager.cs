using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryBookingSystem.Models;
using Microsoft.Extensions.Logging;

namespace DeliveryBookingSystem.Services
{
    public class BookingManager:IRepo<Booking>
    {
        public CustomerContext _context;
        public ILogger<BookingManager> _logger;
        public BookingManager(CustomerContext context, ILogger<BookingManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Booking t)
        {
            try
            {
                _context.booking.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Booking Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll()
        {
            try
            {
                if ((_context.booking) == null)
                    return null;
                return _context.booking.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public int Login(Booking t)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Booking t)
        {
            throw new NotImplementedException();
        }
    }
}
