using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Model;
using EmployeeManagement.Model.DTO;
using Technical_Assesment.Data;
using AutoMapper;

namespace Technical_Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public InventoriesController(ApplicationDbContext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventories>>> GetInventories()
        {
          if (_context.Inventories == null)
          {
              return NotFound();
          }
            return await _context.Inventories.Include(x=>x.Customers).ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventories>> GetInventories(int id)
        {
          if (_context.Inventories == null)
          {
              return NotFound();
          }
            var inventories = await _context.Inventories.FindAsync(id);

            if (inventories == null)
            {
                return NotFound();
            }

            return inventories;
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventories(int id, Inventory_DTO inventories)
        {
            var Inventories = _mapper.Map<Inventories>(inventories);

            if (id != inventories.Id)
            {
                return BadRequest();
            }

            _context.Entry(Inventories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoriesExists(id))
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

        // POST: api/Inventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventories>> PostInventories(Inventory_DTO inventories)
        {
            var Inventories = _mapper.Map<Inventories>(inventories);

            if (_context.Inventories == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Inventories'  is null.");
          }
            _context.Inventories.Add(Inventories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventories", new { id = Inventories.Id }, Inventories);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventories(int id)
        {
            if (_context.Inventories == null)
            {
                return NotFound();
            }
            var inventories = await _context.Inventories.FindAsync(id);
            if (inventories == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventories);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoriesExists(int id)
        {
            return (_context.Inventories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
