using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CurrenciesAPI.Models;

namespace CurrenciesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoursController : ControllerBase
    {
        private readonly CurrenciesDBContext _context;

        public ColoursController(CurrenciesDBContext context)
        {
            _context = context;
        }

        // GET: api/Colours
        [HttpGet]
        public IEnumerable<Colours> GetColours()
        {

            return _context.Colours; //context = database
            
        }

        // GET: api/Colours/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColours([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colours = await _context.Colours.FindAsync(id);

            if (colours == null)
            {
                return NotFound();
            }

            return Ok(colours);
        }

        // PUT: api/Colours/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColours([FromRoute] int id, [FromBody] Colours colours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colours.Id)
            {
                return BadRequest();
            }

            _context.Entry(colours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColoursExists(id))
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

        // POST: api/Colours
        [HttpPost]
        public async Task<IActionResult> PostColours([FromBody] Colours colours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Colours.Add(colours);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColours", new { id = colours.Id }, colours);
        }

        // DELETE: api/Colours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColours([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colours = await _context.Colours.FindAsync(id);
            if (colours == null)
            {
                return NotFound();
            }

            _context.Colours.Remove(colours);
            await _context.SaveChangesAsync();

            return Ok(colours);
        }

        private bool ColoursExists(int id)
        {
            return _context.Colours.Any(e => e.Id == id);
        }
    }
}