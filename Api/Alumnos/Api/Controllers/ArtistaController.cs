using Api.Comun.Interfaces;
using Api.Comun.Modelos.Artista;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("Artista")]
[ApiController]
public class ArtistaController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;

    public ArtistaController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    // Crear artista
    [HttpPost]
    public async Task<ActionResult<int>> Crear([FromBody] CrearArtistaDto dto, CancellationToken cancelacionToken)
    {
        var artista = new Artista
        {
            Nombre = dto.Nombre,
            Imagen = dto.Imagen,
            Descripcion = dto.Descripcion,
            Slug = dto.Nombre.ToLower().Replace(" ", "-"),
            Habilitado = true
        };

        await _contexto.Artistas.AddAsync(artista, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(artista.Id);
    }

    // Modificar artista
    [HttpPut("{Slug}")]
    public async Task<IActionResult> Modificar([FromBody] ModificarArtistaDto dto, CancellationToken cancelacionToken)
    {
        var artista = await _contexto.Artistas.FirstOrDefaultAsync(x => x.Nombre == dto.Slug, cancelacionToken);

        if (artista == null)
            return NotFound();
        
        artista.Descripcion = dto.Descripcion;
        artista.Slug = dto.Nombre.ToLower().Replace(" ", "-");

        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(dto);
    }

    // Habilitar/deshabilitar artista
    [HttpPatch("{Slug}/habilitar")]
    public async Task<IActionResult> Habilitar([FromBody] HabilitarArtistaDto dto, CancellationToken cancelacionToken)
    {
        var artista = await _contexto.Artistas.FirstOrDefaultAsync(x => x.Nombre == dto.Slug, cancelacionToken);

        if (artista == null)
            return NotFound();

        artista.Habilitado = dto.Habilitado;
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok();
    }

    // Consultar artista por id
    [HttpGet("{Slug}")]
    public async Task<ActionResult<BuscarArtistaDto>> Buscar(string Slug, CancellationToken cancelacionToken)
    {
        var artista = await _contexto.Artistas.FirstOrDefaultAsync(x => x.Nombre == Slug, cancelacionToken);

        if (artista == null)
            return NotFound();

        return Ok(artista.ConvertirDto());
    }

    // Consultar todos los artistas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BuscarArtistaDto>>> BuscarTodos(CancellationToken cancelacionToken)
    {
        var lista = await _contexto.Artistas.ToListAsync(cancelacionToken);
        return Ok(lista.ConvertAll(x => x.ConvertirDto()));
    }
}
