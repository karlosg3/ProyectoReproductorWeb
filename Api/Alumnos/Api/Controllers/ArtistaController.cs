using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Entidades;
using Api.Persistencia; 
using Api.Comun.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly AplicacionBdContexto _context;

        public ArtistaController(AplicacionBdContexto context)
        {
            _context = context;
        }

        // GET: api/artista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtistas()
        {
            return await _context.Artistas.ToListAsync();
        }

        // GET: api/artista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetArtista(int id)
        {
            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return artista;
        }

        // POST: api/artista
        [HttpPost]
        public async Task<ActionResult<Artista>> CrearArtista(Artista artista)
        {
            _context.Artistas.Add(artista);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArtista), new { id = artista.Id }, artista);
        }

        // PUT: api/artista/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarArtista(int id, Artista artista)
        {
            if (id != artista.Id)
            {
                return BadRequest();
            }

            _context.Entry(artista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistaExiste(id))
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

        // DELETE: api/artista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarArtista(int id)
        {
            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }

            _context.Artistas.Remove(artista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistaExiste(int id)
        {
            return _context.Artistas.Any(e => e.Id == id);
        }
    }
}
