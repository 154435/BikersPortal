using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikersPortal.Data;
using BikersPortal.Models;
using Microsoft.Extensions.Logging;

namespace BikersPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductTypesController> _logger;

        public ProductTypesController(
               ApplicationDbContext context,
               ILogger<ProductTypesController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: api/ProductTypes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        //{
        //    return await _context.ProductTypes.ToListAsync();
        //}
        public async Task<IActionResult> GetProductTypes()
        {
            try
            {
                var pc = await _context.ProductTypes.ToListAsync();     //pc= Product Types
                if (pc == null)
                {
                    _logger.LogWarning("No Categories were found");
                    return NotFound();
                }
                _logger.LogInformation("Extracted all the categories");
                return Ok(pc);
            }
            catch
            {
                _logger.LogError("Attempt made to retrieve information");
                return BadRequest();
            }
        }

        // GET: api/ProductTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductTypes(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var category = await _context.ProductTypes.FindAsync(id);
                if (category == null) { return NotFound(); }
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }


        }


        // PUT: api/ProductTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductType(int id, ProductType productType)
        {
            if (id != productType.ProductTypeId)
            {
                return BadRequest();
            }

            _context.Entry(productType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductType>> PostProductType(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductType", new { id = productType.ProductTypeId }, productType);
        }

        // DELETE: api/ProductTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductType(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var ProductTypes = await _context.ProductTypes.FindAsync(id);
                if (ProductTypes == null)
                {
                    return NotFound();
                }

                _context.ProductTypes.Remove(ProductTypes);
                await _context.SaveChangesAsync();

                return Ok(ProductTypes);
            }
            catch
            {
                return BadRequest();
            }

        }

        private bool ProductTypeExists(int id)
        {
            return _context.ProductTypes.Any(e => e.ProductTypeId == id);
        }
    }
}
