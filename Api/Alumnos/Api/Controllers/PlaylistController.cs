using Api.Comun.Interfaces;
using Api.Comun.Modelos.Playlist;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

// [Authorize]
[Route("playlists")]
[ApiController]
public class PlaylistController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;

    public PlaylistController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    // Buscar playlists por nombre y habilitado
    [HttpGet]
    public async Task<List<BuscarPlaylistDto>> ObtenerPlaylists(string? nombre, bool habilitado)
    {
        var query = _contexto.Playlists.Where(x => x.Habilitado == habilitado);

        if (!string.IsNullOrEmpty(nombre))
        {
            query = query.Where(x => x.Nombre.Contains(nombre));
        }

        var lista = await query.ToListAsync();
        return lista.ConvertAll(x => x.ConvertirDto());
    }

    // Obtener una playlist por slug
    [HttpGet("{slug}")]
    public async Task<ActionResult<BuscarPlaylistDto>> ObtenerPlaylist(string slug, CancellationToken cancelacionToken)
    {
        var playlist = await _contexto.Playlists
            .FirstOrDefaultAsync(x => x.Slug == slug, cancelacionToken);

        if (playlist == null)
            return NotFound();

        return Ok(playlist.ConvertirDto());
    }

    // Crear nueva playlist
    [HttpPost]
    public async Task<string> CrearPlaylist([FromBody] CrearPlaylistDto dto, CancellationToken cancelacionToken)
    {
        var nuevaPlaylist = new Playlist
        {
            Slug = dto.Nombre.ToLower().Replace(" ", "-"),
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Imagen = dto.Imagen,
            FechaCreacion = dto.FechaCreacion,
            IdUsuario = dto.IdUsuario
        };

        await _contexto.Playlists.AddAsync(nuevaPlaylist, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return nuevaPlaylist.Slug;
    }

    // Modificar playlist
    [HttpPut("{slug}")]
    public async Task<ActionResult<BuscarPlaylistDto>> ModificarPlaylist([FromBody] ModificarPlaylistDto dto, CancellationToken cancelacionToken)
    {
        var playlist = await _contexto.Playlists
            .FirstOrDefaultAsync(x => x.Nombre == dto.Slug, cancelacionToken);

        if (playlist == null)
            return NotFound();

        playlist.Nombre = dto.Nombre;
        playlist.Descripcion = dto.Descripcion;
        playlist.Slug = dto.Nombre.ToLower().Replace(" ", "-");

        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(playlist.ConvertirDto());
    }

    // Habilitar o deshabilitar playlist
    [HttpPatch("{slug}")]
    public async Task<bool> CambiarHabilitado([FromBody] HabilitarPlaylistDto dto, CancellationToken cancelacionToken)
    {
        var playlist = await _contexto.Playlists
            .FirstOrDefaultAsync(x => x.Nombre == dto.Slug, cancelacionToken);

        if (playlist == null)
            return false;

        playlist.Habilitado = dto.Habilitado;
        await _contexto.SaveChangesAsync(cancelacionToken);

        return true;
    }
}