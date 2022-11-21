using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP03API.Data;
using TP03API.Models;

namespace TP03API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly TP03Context _context;

        public LivroController(TP03Context context)
        {
            _context = context;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livros>>> GetLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        // GET: api/Livros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livros>> GetLogin(int id)
        {
            var livros = await _context.Livros.FindAsync(id);

            if (livros == null)
            {
                return NotFound();
            }

            return livros;
        }

        // PUT: api/Livros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivros(int id, Livros livros)
        {
            if (id != livros.Id)
            {
                return BadRequest();
            }

            _context.Entry(livros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivrosExists(id))
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

        // POST: api/Livros
        [HttpPost]
        public async Task<ActionResult<Livros>> PostLivros(Livros livros)
        {
            _context.Livros.Add(livros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivros", new { id = livros.Id }, livros);
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            var livros = await _context.Livros.FindAsync(id);
            if (livros == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivrosExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
