using Api.Comun.Interfaces;
using Api.Comun.Modelos.GenerosMusicales;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

// [Authorize]
[Route("GeneroMusical")]
[ApiController]
public class GeneroController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;

    public GeneroController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    // Crear género musical
    [HttpPost]
    public async Task<ActionResult<string>> RegistrarGenero([FromBody] CrearGeneroMusicalDto dto, CancellationToken cancelacionToken)
    {
        var nuevoGenero = new Genero
        {
            Nombre = dto.Nombre,
            Slug = dto.Nombre.ToLower().Replace(" ", "-") // Generación de slug simple
        };

        await _contexto.Generos.AddAsync(nuevoGenero, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(nuevoGenero.Slug);
    }

    // Modificar género musical
    [HttpPut("{slug}")]
    public async Task<IActionResult> ModificarGenero([FromBody] ModificarGeneroMusicalDto dto, CancellationToken cancelacionToken)
    {
        var genero = await _contexto.Generos
            .FirstOrDefaultAsync(x => x.Slug == dto.Slug, cancelacionToken);

        if (genero == null)
            return NotFound();

        genero.Nombre = dto.Nombre;
        genero.Slug = dto.Slug.ToLower().Replace(" ", "-"); // Opcional: actualizar slug si el nombre cambia

        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(dto);
    }
}
