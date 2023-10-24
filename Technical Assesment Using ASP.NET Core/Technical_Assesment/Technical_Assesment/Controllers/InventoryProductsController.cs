using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_Assesment.Data;
using Technical_Assesment.Model;
using Technical_Assesment.Model.DTO;

namespace Technical_Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public InventoryProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/InventoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryProduct>>> GetInventoryProduct()
        {
            if (_context.InventoryProduct == null)
            {
                return NotFound();
            }
            return await _context.InventoryProduct
                .Include(x=>x.Inventory)
                .Include(x=>x.Product)
                .Include(x=>x.Inventory.Customers)
                .ToListAsync();
        }

        // GET: api/InventoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryProduct>> GetInventoryProduct(int id)
        {
            if (_context.InventoryProduct == null)
            {
                return NotFound();
            }
            var inventoryProduct = await _context.InventoryProduct.FindAsync(id);

            if (inventoryProduct == null)
            {
                return NotFound();
            }

            return inventoryProduct;
        }

        [HttpGet("GetInventoryProduct/{billNo}")]
        public async Task<ActionResult<IList<InventoryProduct>>> GetInventoryProduct(string billNo)
        {
            if (_context.InventoryProduct == null)
            {
                return NotFound();
            }
            var inventoryProduct = await _context.InventoryProduct
                .Include(x => x.Inventory)
                .Include(x => x.Product)
                .Include(x => x.Inventory.Customers)
                .Where(x => x.Inventory.BillNo == billNo).ToListAsync();
               // .FirstOrDefaultAsync();

            if (inventoryProduct == null)
            {
                return NotFound();
            }

            return inventoryProduct;
        }

        // PUT: api/InventoryProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryProduct(int id, InventoryProduct_DTO inventoryProduct)
        {
            var InventoryProduct = _mapper.Map<InventoryProduct>(inventoryProduct);
            if (id != inventoryProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(InventoryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryProductExists(id))
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

        // POST: api/InventoryProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryProduct>> PostInventoryProduct(InventoryProduct_DTO inventoryProduct)
        {
            var InventoryProduct = _mapper.Map<InventoryProduct>(inventoryProduct);
            if (_context.InventoryProduct == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InventoryProduct'  is null.");
            }
            _context.InventoryProduct.Add(InventoryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryProduct", new { id = inventoryProduct.Id }, inventoryProduct);
        }

        // DELETE: api/InventoryProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryProduct(int id)
        {
            if (_context.InventoryProduct == null)
            {
                return NotFound();
            }
            var inventoryProduct = await _context.InventoryProduct.FindAsync(id);
            if (inventoryProduct == null)
            {
                return NotFound();
            }

            _context.InventoryProduct.Remove(inventoryProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryProductExists(int id)
        {
            return (_context.InventoryProduct?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
