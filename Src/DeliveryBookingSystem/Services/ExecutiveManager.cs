using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryBookingSystem.Models;
using Microsoft.Extensions.Logging;

namespace DeliveryBookingSystem.Services
{
    public class ExecutiveManager:IRepo<DeliveryExecutive>
    {
        public CustomerContext _context;
        public ILogger<ExecutiveManager> _logger;
        public ExecutiveManager(CustomerContext context, ILogger<ExecutiveManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(DeliveryExecutive t)
        {
            try
            {
                _context.deliveryexecutive.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }
            public DeliveryExecutive Get(int id)
            {
                try
                {
                    DeliveryExecutive delivery = _context.deliveryexecutive.FirstOrDefault(a => a.ExecutiveId == id);
                    return delivery;
                }
                catch (Exception e)
                {
                    _logger.LogDebug(e.Message);
                }
                return null;
            }
        

        public IEnumerable<DeliveryExecutive> GetAll()
        {
            try
            {
                if ((_context.deliveryexecutive) == null)
                    return null;
                return _context.deliveryexecutive.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;

        }

        public int Login(DeliveryExecutive t)
        {
            DeliveryExecutive obj = _context.deliveryexecutive.Where(i => i.UserName.Equals(t.UserName) && i.Password.Equals(t.Password)&&i.IsVerified.Equals("Yes")).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.ExecutiveId;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }

        public void Update(int id, DeliveryExecutive t)
        {
            DeliveryExecutive delivery = Get(id);
            if (delivery != null)
            {
                delivery.IsVerified = t.IsVerified;
            }
            _context.SaveChanges();
        }
    }
}

    
