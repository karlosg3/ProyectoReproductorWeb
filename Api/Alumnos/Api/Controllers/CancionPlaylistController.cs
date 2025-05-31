using Api.Comun.Interfaces;
using Api.Comun.Modelos.CancionPlaylist;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CancionPlaylistController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;

    public CancionPlaylistController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    [HttpGet("{Slug}")]
    public async Task<IActionResult> ObtenerCanciones(string Slug, CancellationToken cancelacionToken)
    {
        var playlist = await _contexto.Playlists
                .Include(p => p.CancionPlaylists)
                .ThenInclude(cp => cp.Cancion)
                .FirstOrDefaultAsync(p => p.Slug == Slug);

        if (playlist == null)
        {
            return NotFound("Playlist no encontrada.");
        }

        var canciones = playlist.CancionPlaylists
                .OrderBy(cp => cp.FechaRegistro)
                .Select(cp => new
                {
                    cp.Cancion.Id,
                    cp.Cancion.Titulo,
                    cp.Cancion.Duracion,
                    cp.FechaRegistro
                }).ToList();

        return Ok(canciones);
    }

    [HttpPost]
    public async Task<IActionResult> AgregarCancion([FromBody] AgregarCancionAPlaylistDto dto, CancellationToken cancelacionToken)
    {
        // Buscamos la playlist por slug (no por ID)
        var playlist = await _contexto.Playlists.FirstOrDefaultAsync(p => p.Slug == dto.IdPlaylist.ToString());

        if (playlist == null)
        {
            return NotFound("Playlist no encontrada.");
        }

        // Verificar si ya existe esa relación (opcional)
        var existe = await _contexto.CancionesPlaylist.AnyAsync(cp =>
            cp.IdPlaylist == playlist.Id && cp.IdCancion == dto.IdCancion);

        if (existe)
        {
            return BadRequest("La canción ya está en la playlist.");
        }

        var cancionPlaylist = new CancionPlaylist
        {
            IdPlaylist = playlist.Id,
            IdCancion = dto.IdCancion
        };

        _contexto.CancionesPlaylist.Add(cancionPlaylist);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok("Canción agregada a la playlist.");
    }

    [HttpPatch("Habilitar")]
    public async Task<IActionResult> HabilitarCancionEnPlaylist([FromBody] DeshabilitarCancionDePlaylistDto dto, CancellationToken cancelacionToken)
    {
        // Buscar la playlist por slug
        var playlist = await _contexto.Playlists.FirstOrDefaultAsync(p => p.Slug == dto.IdPlaylist.ToString());
        if (playlist == null)
        {
            return NotFound("Playlist no encontrada.");
        }

        // Buscar la relación en CancionPlaylist
        var cancionPlaylist = await _contexto.CancionesPlaylist.FirstOrDefaultAsync(cp =>
            cp.IdPlaylist == playlist.Id && cp.IdCancion == dto.IdCancion);

        if (cancionPlaylist == null)
        {
            return NotFound("La canción no está en la playlist.");
        }

        // Actualizar habilitado
        cancionPlaylist.Habilitado = dto.Habilitado;

        await _contexto.SaveChangesAsync(cancelacionToken);
        return Ok($"La canción ha sido {(dto.Habilitado ? "habilitada" : "deshabilitada")} en la playlist.");
    }       
}
