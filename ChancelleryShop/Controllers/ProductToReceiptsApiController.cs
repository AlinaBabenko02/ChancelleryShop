using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChancelleryShop;

namespace ChancelleryShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductToReceiptsApiController : ControllerBase
    {
        private readonly ChancelleryContext _context;

        public ProductToReceiptsApiController(ChancelleryContext context)
        {
            _context = context;
        }

        // GET: api/ProductToReceipts1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReceipt>>> GetProductToReceipts()
        {
            return await _context.ProductToReceipts.ToListAsync();
        }

        // GET: api/ProductToReceipts1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReceipt>> GetProductToReceipt(int id)
        {
            var productToReceipt = await _context.ProductToReceipts.FindAsync(id);

            if (productToReceipt == null)
            {
                return NotFound();
            }

            return productToReceipt;
        }

        // PUT: api/ProductToReceipts1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductToReceipt(int id, ProductToReceipt productToReceipt)
        {
            if (id != productToReceipt.ProductToReceiptId)
            {
                return BadRequest();
            }

            _context.Entry(productToReceipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductToReceiptExists(id))
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

        // POST: api/ProductToReceipts1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductToReceipt>> PostProductToReceipt(ProductToReceipt productToReceipt)
        {
            _context.ProductToReceipts.Add(productToReceipt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductToReceipt", new { id = productToReceipt.ProductToReceiptId }, productToReceipt);
        }

        // DELETE: api/ProductToReceipts1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductToReceipt(int id)
        {
            var productToReceipt = await _context.ProductToReceipts.FindAsync(id);
            if (productToReceipt == null)
            {
                return NotFound();
            }

            _context.ProductToReceipts.Remove(productToReceipt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductToReceiptExists(int id)
        {
            return _context.ProductToReceipts.Any(e => e.ProductToReceiptId == id);
        }
    }
}
