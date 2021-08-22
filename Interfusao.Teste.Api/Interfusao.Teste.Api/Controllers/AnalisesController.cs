using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Interfusao.Teste.Api.DataAccess;
using Interfusao.Teste.Api.Models;

namespace Interfusao.Teste.Api.Controllers
{

    //Controller criada via scaffolding

    [Route("api/[controller]")]
    [ApiController]
    public class AnalisesController : ControllerBase
    {
        private readonly DataContext _context;

        public AnalisesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Analises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analise>>> GetAnaliseEntity()
        {
            return await _context.AnaliseEntity.ToListAsync();
        }

        // GET: api/Analises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Analise>> GetAnalise(int id)
        {
            var analise = await _context.AnaliseEntity.FindAsync(id);

            if (analise == null)
            {
                return NotFound();
            }

            return analise;
        }

        // PUT: api/Analises/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalise(int id, Analise analise)
        {
            if (id != analise.Id)
            {
                return BadRequest();
            }

            _context.Entry(analise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnaliseExists(id))
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

        // POST: api/Analises
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Analise>> PostAnalise(Analise analise)
        {
            _context.AnaliseEntity.Add(analise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalise", new { id = analise.Id }, analise);
        }

        // DELETE: api/Analises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Analise>> DeleteAnalise(int id)
        {
            var analise = await _context.AnaliseEntity.FindAsync(id);
            if (analise == null)
            {
                return NotFound();
            }

            _context.AnaliseEntity.Remove(analise);
            await _context.SaveChangesAsync();

            return analise;
        }

        private bool AnaliseExists(int id)
        {
            return _context.AnaliseEntity.Any(e => e.Id == id);
        }
    }
}
