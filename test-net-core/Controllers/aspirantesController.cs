using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_net_core.Data;
using test_net_core.Models;

namespace test_net_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class aspirantesController : ControllerBase
    {
        private readonly test_net_coreContext _context;

        public aspirantesController(test_net_coreContext context)
        {
            _context = context;
        }

        // GET: api/aspirantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<aspirantes>>> Getaspirantes()
        {
            return await _context.aspirantes.ToListAsync();
        }

        // GET: api/aspirantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<aspirantes>> Getaspirantes(int id)
        {
            var aspirantes = await _context.aspirantes.FindAsync(id);

            if (aspirantes == null)
            {
                return NotFound();
            }

            return aspirantes;
        }

        // PUT: api/aspirantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaspirantes(int id, aspirantes aspirantes)
        {
           

            _context.Entry(aspirantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspirantesExists(id))
                {
                    return BadRequest("No se puede editar el aspiante porque no existe");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/aspirantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<aspirantes>> Postaspirantes(aspirantes aspirantes)
        {
            try
            {
                _context.aspirantes.Add(aspirantes);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getaspirantes", new { id = aspirantes.id }, aspirantes);
            }

            catch (Exception ex) {
                return BadRequest("No se pudo realizar el registro del aspirante");
            }
        }

        // DELETE: api/aspirantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<aspirantes>> Deleteaspirantes(int id)
        {
            var aspirantes = await _context.aspirantes.FindAsync(id);
            if (aspirantes == null)
            {
                return BadRequest("No se puede eliminar el aspirante porque no existe");
            }

            _context.aspirantes.Remove(aspirantes);
            await _context.SaveChangesAsync();

            return aspirantes;
        }

        private bool aspirantesExists(int id)
        {
            return _context.aspirantes.Any(e => e.id == id);
        }
    }
}
