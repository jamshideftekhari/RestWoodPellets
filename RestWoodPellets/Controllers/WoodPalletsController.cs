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
    public class WoodPalletsController : ControllerBase
    {
        private readonly WoodPalletContext _context;

        public WoodPalletsController(WoodPalletContext context)
        {
            _context = context;
        }

        // GET: api/WoodPallets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WoodPallet>>> GetWoodPallets()
        {
          if (_context.WoodPallets == null)
          {
              return NotFound();
          }
            return await _context.WoodPallets.ToListAsync();
        }

        // GET: api/WoodPallets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WoodPallet>> GetWoodPallet(int id)
        {
          if (_context.WoodPallets == null)
          {
              return NotFound();
          }
            var woodPallet = await _context.WoodPallets.FindAsync(id);

            if (woodPallet == null)
            {
                return NotFound();
            }

            return woodPallet;
        }

        // PUT: api/WoodPallets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWoodPallet(int id, WoodPallet woodPallet)
        {
            if (id != woodPallet.Id)
            {
                return BadRequest();
            }

            _context.Entry(woodPallet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WoodPalletExists(id))
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

        // POST: api/WoodPallets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WoodPallet>> PostWoodPallet(WoodPallet woodPallet)
        {
          if (_context.WoodPallets == null)
          {
              return Problem("Entity set 'WoodPalletContext.WoodPallets'  is null.");
          }
            _context.WoodPallets.Add(woodPallet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWoodPallet", new { id = woodPallet.Id }, woodPallet);
        }

        // DELETE: api/WoodPallets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWoodPallet(int id)
        {
            if (_context.WoodPallets == null)
            {
                return NotFound();
            }
            var woodPallet = await _context.WoodPallets.FindAsync(id);
            if (woodPallet == null)
            {
                return NotFound();
            }

            _context.WoodPallets.Remove(woodPallet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WoodPalletExists(int id)
        {
            return (_context.WoodPallets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
