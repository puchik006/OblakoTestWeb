using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OblakoTestWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OblakoTestWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductsContext db;
        public ProductsController(ProductsContext context)
        {
            db = context;

            if (!db.Product.Any())
            {
                db.Product.Add(new ProductData { Name = "Pen", Description = "a simple pen" });
                db.Product.Add(new ProductData { Name = "Pencil", Description = "a simple pencil" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductData>>> Get()
        {
            return await db.Product.ToListAsync();
        }

        // GET api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductData>> Get(Guid id)
        {
            ProductData Product = await db.Product.FirstOrDefaultAsync(x => x.ID == id);
            if (Product == null)
                return NotFound();
            return new ObjectResult(Product);
        }

        [HttpPost("{name}")]
        public async Task<ActionResult<IEnumerable<ProductData>>> Post(string name)
        {
            return await db.Product.Where(e => e.Name == name).ToListAsync();
        }

        // POST api/Products
        [HttpPost]
        public async Task<ActionResult<ProductData>> Post(ProductData Product)
        {
            if (Product == null)
            {
                return BadRequest();
            }

            db.Product.Add(Product);
            await db.SaveChangesAsync();
            return Ok(Product);
        }


        // PUT api/Products/
        [HttpPut]
        public async Task<ActionResult<ProductData>> Put(ProductData Product)
        {
            if (Product == null)
            {
                return BadRequest();
            }
            if (!db.Product.Any(x => x.ID == Product.ID))
            {
                return NotFound();
            }

            db.Update(Product);
            await db.SaveChangesAsync();
            return Ok(Product);
        }

        // DELETE api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductData>> Delete(Guid id)
        {
            ProductData Product = db.Product.FirstOrDefault(x => x.ID == id);
            if (Product == null)
            {
                return NotFound();
            }
            db.Product.Remove(Product);
            await db.SaveChangesAsync();
            return Ok(Product);
        }
    }
}
