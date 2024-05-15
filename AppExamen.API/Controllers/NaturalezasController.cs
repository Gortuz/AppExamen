using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppExamen.Entidades;

namespace AppExamen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaturalezasController : ControllerBase
    {
        private readonly DbContext _context;

        public NaturalezasController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Naturalezas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Naturaleza>>> GetNaturaleza()
        {
            return await _context.Naturaleza.ToListAsync();
        }

        // GET: api/Naturalezas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Naturaleza>> GetNaturaleza(int id)
        {
            var naturaleza = await _context.Naturaleza.FindAsync(id);

            if (naturaleza == null)
            {
                return NotFound();
            }

            return naturaleza;
        }

        // PUT: api/Naturalezas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaturaleza(int id, Naturaleza naturaleza)
        {
            if (id != naturaleza.Id)
            {
                return BadRequest();
            }

            _context.Entry(naturaleza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaturalezaExists(id))
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

        // POST: api/Naturalezas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Naturaleza>> PostNaturaleza(Naturaleza naturaleza)
        {
            _context.Naturaleza.Add(naturaleza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNaturaleza", new { id = naturaleza.Id }, naturaleza);
        }

        // DELETE: api/Naturalezas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaturaleza(int id)
        {
            var naturaleza = await _context.Naturaleza.FindAsync(id);
            if (naturaleza == null)
            {
                return NotFound();
            }

            _context.Naturaleza.Remove(naturaleza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NaturalezaExists(int id)
        {
            return _context.Naturaleza.Any(e => e.Id == id);
        }
    }
}
