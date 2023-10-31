using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestWoodPellets.Models;

namespace RestWoodPellets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WPConstrainsController : ControllerBase
    {
        private readonly WPConsContext _context;

        public WPConstrainsController(WPConsContext context)
        {
            _context = context;
        }

        // GET: api/WPConstrains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WPConstrains>>> GetwPConsContexts()
        {
          if (_context.wPConsContexts == null)
          {
              return NotFound();
          }
            return await _context.wPConsContexts.ToListAsync();
        }

        // GET: api/WPConstrains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WPConstrains>> GetWPConstrains(int id)
        {
          if (_context.wPConsContexts == null)
          {
              return NotFound();
          }
            var wPConstrains = await _context.wPConsContexts.FindAsync(id);

            if (wPConstrains == null)
            {
                return NotFound();
            }

            return wPConstrains;
        }

        // PUT: api/WPConstrains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWPConstrains(int id, WPConstrains wPConstrains)
        {
            if (id != wPConstrains.Id)
            {
                return BadRequest();
            }

            _context.Entry(wPConstrains).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WPConstrainsExists(id))
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

        // POST: api/WPConstrains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WPConstrains>> PostWPConstrains(WPConstrains wPConstrains)
        {
          if (_context.wPConsContexts == null)
          {
              return Problem("Entity set 'WPConsContext.wPConsContexts'  is null.");
          }
            _context.wPConsContexts.Add(wPConstrains);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWPConstrains", new { id = wPConstrains.Id }, wPConstrains);
        }

        // DELETE: api/WPConstrains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWPConstrains(int id)
        {
            if (_context.wPConsContexts == null)
            {
                return NotFound();
            }
            var wPConstrains = await _context.wPConsContexts.FindAsync(id);
            if (wPConstrains == null)
            {
                return NotFound();
            }

            _context.wPConsContexts.Remove(wPConstrains);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WPConstrainsExists(int id)
        {
            return (_context.wPConsContexts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
