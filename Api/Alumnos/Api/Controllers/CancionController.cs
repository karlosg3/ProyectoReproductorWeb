using Api.Comun.Interfaces;
using Api.Comun.Modelos.Cancion;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("Cancion")]
[ApiController]
public class CancionController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;

    public CancionController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    // Crear canción
    [HttpPost]
    public async Task<ActionResult<int>> Crear([FromBody] CrearCancionDto dto, CancellationToken cancelacionToken)
    {
        var cancion = new Cancion
        {
            Titulo = dto.Titulo,
            ArchivoAudio = dto.ArchivoDeAudio,
            NumeroPista = dto.NumeroPista,
            Reproducciones = 0,
            FechaLanzamiento = dto.FechaDeLanzamiento,
            Slug = dto.Titulo.ToLower().Replace(" ", "-"),
            Habilitado = true,
            AlbumId = dto.IdAlbum
        };

        await _contexto.Canciones.AddAsync(cancion, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        foreach (var idArtista in dto.IdsArtistas)
        {
            var colaboracion = new Colaboracion
            {
                CancionId = cancion.Id,
                ArtistaId = idArtista
            };

            await _contexto.Colaboraciones.AddAsync(colaboracion, cancelacionToken);
        }

        return Ok(cancion.Id);
    }

    // Habilitar/deshabilitar canción
    [HttpPatch("{Slug}/habilitar")]
    public async Task<IActionResult> Habilitar([FromBody] HabilitadoCancionDto dto, CancellationToken cancelacionToken)
    {
        var cancion = await _contexto.Canciones.FirstOrDefaultAsync(x => x.Titulo == dto.Slug, cancelacionToken);

        if (cancion == null)
            return NotFound();

        cancion.Habilitado = dto.Habilitado;
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok();
    }

    // Consultar canción por id
    [HttpGet("{Slug}")]
    public async Task<ActionResult<BuscarCancionDto>> Buscar(string Slug, CancellationToken cancelacionToken)
    {
        var cancion = await _contexto.Canciones.FirstOrDefaultAsync(x => x.Titulo == Slug, cancelacionToken);

        if (cancion == null)
            return NotFound();

        return Ok(cancion.ConvertirDto());
    }

    // Consultar todas las canciones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BuscarCancionDto>>> BuscarTodos(CancellationToken cancelacionToken)
    {
        var lista = await _contexto.Canciones.ToListAsync(cancelacionToken);
        return Ok(lista.ConvertAll(x => x.ConvertirDto()));
    }
}
