using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CurrenciesAPI.Models;
using CurrenciesAPI.Models.DTOs;

namespace CurrenciesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly CurrenciesDBContext _context;

        public CurrenciesController(CurrenciesDBContext context)
        {
            _context = context;
        }

        // GET: api/Currencies
        [HttpGet]
        public IEnumerable<Currencies> GetCurrencies()
        {
            return _context.Currencies;
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currencies = await _context.Currencies.FindAsync(id);

            if (currencies == null)
            {
                return NotFound();
            }

            return Ok(currencies);
        }

        // PUT: api/Currencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrencies([FromRoute] int id, [FromBody] Currencies currencies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currencies.Id)
            {
                return BadRequest();
            }

            _context.Entry(currencies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrenciesExists(id))
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

        // POST: api/Currencies
        [HttpPost]
        public async Task<IActionResult> PostCurrencies([FromBody] Currencies currencies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Currencies.Add(currencies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrencies", new { id = currencies.Id }, currencies);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrencies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currencies = await _context.Currencies.FindAsync(id);
            if (currencies == null)
            {
                return NotFound();
            }

            _context.Currencies.Remove(currencies);
            await _context.SaveChangesAsync();

            return Ok(currencies);
        }

        private bool CurrenciesExists(int id)
        {
            return _context.Currencies.Any(e => e.Id == id);
        }
    }
}