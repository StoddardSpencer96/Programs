using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CurrenciesAPI.Models;
using CurrenciesAPI.Models.DTOs;
using CurrenciesDAL.Models;

namespace CurrenciesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly CurrenciesDBContext _context;

        public TypesController(CurrenciesDBContext context)
        {
            _context = context;
        }

        // GET: api/Types
        [HttpGet]
        public IEnumerable<Types> GetTypes()
        {
            //LINQ query language
            return _context.Types;
        }

        //    List<TypeDTO> typeDTOList = new List<TypeDTO>(); //make a new typeDTO list

        //    //loop through the list, and make a new DTO for each one
        //    //and add to DTO list
        //    foreach(Types t in types)
        //    {
        //        //make a new DTO
        //        TypeDTO dto = new TypeDTO()
        //        {
        //            TypeId = t.Id,
        //            Name = t.Name
          
        //        };

        //        //add DTO to the DTOList
        //        typeDTOList.Add(dto);
        //    }

        //    //return the DTOList
        //    return typeDTOList;
        //}

        // GET: api/Types/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var types = await _context.Types.FindAsync(id);

            if (types == null)
            {
                return NotFound();
            }

            return Ok(types);
        }

        // PUT: api/Types/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypes([FromRoute] int id, [FromBody] Types types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != types.Id)
            {
                return BadRequest();
            }

            _context.Entry(types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesExists(id))
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

        // POST: api/Types
        [HttpPost]
        public async Task<IActionResult> PostTypes([FromBody] Types types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Types.Add(types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypes", new { id = types.Id }, types);
        }

        // DELETE: api/Types/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var types = await _context.Types.FindAsync(id);
            if (types == null)
            {
                return NotFound();
            }

            _context.Types.Remove(types);
            await _context.SaveChangesAsync();

            return Ok(types);
        }

        private bool TypesExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}