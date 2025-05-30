using Api.Comun.Interfaces;
using Api.Comun.Modelos.Cancion;
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
            NumeroPista = dto.NumeroDePista,
            Reproducciones = 0,
            FechaLanzamiento = dto.FechaDeLanzamiento,
            Slug = dto.Titulo.ToLower().Replace(" ", "-"),
            Habilitado = true,
            AlbumId = dto.AlbumId,
            IdArtista = dto.IdArtista
        };

        await _contexto.Canciones.AddAsync(cancion, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(cancion.Id);
    }

    // Modificar canción
    [HttpPut("{id}")]
    public async Task<IActionResult> Modificar([FromBody] ModificarCancionDto dto, CancellationToken cancelacionToken)
    {
        var cancion = await _contexto.Canciones.FirstOrDefaultAsync(x => x.Id == dto.Id, cancelacionToken);

        if (cancion == null)
            return NotFound();

        cancion.Titulo = dto.Titulo;
        cancion.Duracion = dto.Duracion;
        cancion.ArchivoDeAudio = dto.ArchivoDeAudio;
        cancion.NumeroDePista = dto.NumeroDePista;
        cancion.FechaDeLanzamiento = dto.FechaDeLanzamiento;
        cancion.Slug = dto.Titulo.ToLower().Replace(" ", "-");
        cancion.AlbumId = dto.AlbumId;
        cancion.ArtistaId = dto.ArtistaId;

        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(dto);
    }

    // Habilitar/deshabilitar canción
    [HttpPatch("{id}/habilitar")]
    public async Task<IActionResult> Habilitar([FromBody] HabilitadoCancionDto dto, CancellationToken cancelacionToken)
    {
        var cancion = await _contexto.Canciones.FirstOrDefaultAsync(x => x.Id == dto.Id, cancelacionToken);

        if (cancion == null)
            return NotFound();

        cancion.Habilitado = dto.Habilitado;
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok();
    }

    // Consultar canción por id
    [HttpGet("{id}")]
    public async Task<ActionResult<BuscarCancionDto>> Buscar(int id, CancellationToken cancelacionToken)
    {
        var cancion = await _contexto.Canciones.FirstOrDefaultAsync(x => x.Id == id, cancelacionToken);

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
