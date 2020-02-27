using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TryOut01.Model;

namespace TryOut01.Controllers
{
    [ApiController]
    [Route("/api/v1/driver")]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        private readonly dbOnlineContext _context;

        public DriverController(ILogger<DriverController> logger,dbOnlineContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateDriver()
        {
            var driv = new Driver
            {   
                FullName = "Johny Doe",
                PhoneNumber = "08123456789",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Drivers.Add(driv);
            _context.SaveChanges();

            return Ok(driv);
        }
        
        [HttpGet]
        public IActionResult GetDrivers()
        {
            var driv = _context.Drivers;
            return Ok(new {
                message = "success retrieve data",
                status = true,
                data = driv
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var driv = _context.Drivers.First(a => a.Id == id);
            return Ok(new {
                message = "success retrieve data",
                status = true,
                data = driv
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            var driv = _context.Drivers.First(a => a.Id == id);
            driv.FullName = "Stevie Donny";
            _context.SaveChanges();

            return Ok(driv);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var driv = _context.Drivers.First(a => a.Id == id);
            _context.Drivers.Remove(driv);
            _context.SaveChangesAsync();

            return Ok(driv);
        }
    }
}