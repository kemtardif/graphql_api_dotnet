using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GraphQL_API.Entities;

namespace GraphQL_API.Controllers
{
    [Route("api/FactInterventions")]
    [ApiController]
    public class FactInterventionsController : ControllerBase
    {
        private readonly cindy_okino_warehouseContext _context;

        public FactInterventionsController(cindy_okino_warehouseContext context)
        {
            _context = context;
        }

        // GET: api/FactInterventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactIntervention>>> GetFactInterventions()
        {
            return await _context.FactInterventions.ToListAsync();
        }

        // GET: api/FactInterventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactIntervention>> GetFactIntervention(long id)
        {
            var factIntervention = await _context.FactInterventions.FindAsync(id);

            if (factIntervention == null)
            {
                return NotFound();
            }

            return factIntervention;
        }

        // PUT: api/FactInterventions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactIntervention(long id, FactIntervention factIntervention)
        {
            if (id != factIntervention.Id)
            {
                return BadRequest();
            }

            _context.Entry(factIntervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactInterventionExists(id))
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

        // POST: api/FactInterventions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FactIntervention>> PostFactIntervention(FactIntervention factIntervention)
        {
            _context.FactInterventions.Add(factIntervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactIntervention", new { id = factIntervention.Id }, factIntervention);
        }

        // DELETE: api/FactInterventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FactIntervention>> DeleteFactIntervention(long id)
        {
            var factIntervention = await _context.FactInterventions.FindAsync(id);
            if (factIntervention == null)
            {
                return NotFound();
            }

            _context.FactInterventions.Remove(factIntervention);
            await _context.SaveChangesAsync();

            return factIntervention;
        }

        private bool FactInterventionExists(long id)
        {
            return _context.FactInterventions.Any(e => e.Id == id);
        }
    }
}
