using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TryOut01.Model;

namespace TryOut01.Controllers
{
    [ApiController]
    [Route("/api/v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly dbOnlineContext _context;

        public ProductController(ILogger<ProductController> logger,dbOnlineContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateProduct()
        {
            var prod = new Product
            {   
                Name = "Apple",
                Price = 100000,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Products.Add(prod);
            _context.SaveChanges();

            return Ok(prod);
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            var prod = _context.Products;
            return Ok(new {
                message = "success retrieve data",
                status = true,
                data = prod
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var prod = _context.Products.First(a => a.Id == id);
            return Ok(new {
                message = "success retrieve data",
                status = true,
                data = prod
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            var prod = _context.Products.First(a => a.Id == id);
            prod.Price = 50000;
            _context.SaveChanges();

            return Ok(prod);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prod = _context.Products.First(a => a.Id == id);
            _context.Products.Remove(prod);
            _context.SaveChangesAsync();

            return Ok(prod);
        }
    }
}