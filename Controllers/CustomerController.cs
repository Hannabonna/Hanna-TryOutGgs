using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TryOut01.Model;

namespace TryOut01.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly dbOnlineContext _context;

        public CustomerController(ILogger<CustomerController> logger,dbOnlineContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateCustomer()
        {
            var custom = new Customer
            {   
                FullName = "Johny Doe",
                Username = "doe",
                Email = "john@doe.com",
                PhoneNumber = "08123456789",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Customers.Add(custom);
            _context.SaveChanges();

            return Ok(custom);
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var custom = _context.Customers;
            return Ok(new {
                message = "success retrieve data",
                status = true,
                data = custom
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var custom = _context.Customers.First(a => a.Id == id);
            return Ok(new {
                message = "success retrieve data",
                status = true,
                data = custom
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            var custom = _context.Customers.First(a => a.Id == id);
            custom.FullName = "Stevie Worth";
            _context.SaveChanges();
            return Ok(custom);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var custom = _context.Customers.First(a => a.Id == id);
            _context.Customers.Remove(custom);
            _context.SaveChangesAsync();

            return Ok(custom);
        }
    }
}