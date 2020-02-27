using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TryOut01.Model;

namespace TryOut01.Controllers
{
    [ApiController]
    [Route("/api/v1/order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly dbOnlineContext _context;

        public OrderController(ILogger<OrderController> logger,dbOnlineContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateOrder()
        {
            var or = new Order
            {   
                UserId = 2,
                Status = "sending",
                DriverId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Orders.Add(or);
            _context.SaveChanges();

            return Ok(or);
        }
        
        [HttpGet]
        public IActionResult GetOrders()
        {
            var or = _context.Orders;
            return Ok(new {
                message = "success retrieve data",
                status = true,
                data = or
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var or = _context.Orders.First(a => a.Id == id);
            return Ok(new {
                message = "success retrieve data",
                status = true,
                data = or
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            var or = _context.Orders.First(a => a.Id == id);
            or.Status = "completed";
            _context.SaveChanges();

            return Ok(or);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var or = _context.Orders.First(a => a.Id == id);
            _context.Orders.Remove(or);
            _context.SaveChangesAsync();

            return Ok(or);
        }
    }
}