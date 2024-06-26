﻿using System;
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
    public class PokemonesController : ControllerBase
    {
        private readonly DbContext _context;

        public PokemonesController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Pokemones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemon()
        {
            //return await _context.Pokemon.ToListAsync();
            var pokemon = await _context.Pokemon
                .Include(n => n.Naturaleza)
                .ToListAsync();
            return pokemon;
        }

        // GET: api/Pokemones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _context.Pokemon
                .Include(n => n.Naturaleza)
                .Where(n => n.Id == id)
                .FirstOrDefaultAsync();


            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        // PUT: api/Pokemones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemon(int id, Pokemon pokemon)
        {
            if (id != pokemon.Id)
            {
                return BadRequest();
            }

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id))
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

        // POST: api/Pokemones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon(Pokemon pokemon)
        {
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPokemon", new { id = pokemon.Id }, pokemon);
        }

        // DELETE: api/Pokemones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.Pokemon.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(e => e.Id == id);
        }
    }
}
