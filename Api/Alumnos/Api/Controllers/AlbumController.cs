using Api.Comun.Interfaces;
using Api.Comun.Modelos.Album;
using Api.Comun.Modelos.AlbumArtista;
using Api.Comun.Modelos.Usuarios;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

//[Authorize]
[Route("album")]
public class AlbumController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;
  

    public AlbumController(IAplicacionBdContexto contexto)
        
    {
        _contexto = contexto;
        
    }

    [HttpGet]
    public async Task<List<BuscarAlbumsDto>> ObtenerAlbums(string nombre, bool habilitado)
    {
        var query = _contexto.Albums.Where(x => x.Habilitado == habilitado);

        if (string.IsNullOrEmpty(nombre) == false)
        {
            query = query.Where(x => x.Nombre.Contains(nombre));
        }
        var lista = await query.ToListAsync();

        return lista.ConvertAll(x => x.ConvertirDto());
    }

    [HttpGet("{slug}")]
    public async Task<BuscarAlbumsDto> ObtenerAlbums(string slug, CancellationToken cancelacionToken)
    {
        var album = await _contexto.Albums.FirstOrDefaultAsync(x => x.Slug == slug, cancelacionToken);

        if (album == null)
            return new BuscarAlbumsDto();

        return album.ConvertirDto();
    }

    [HttpPost]
    public async Task<string> RegistrarAlbum([FromBody] CrearAlbumsDto album, CancellationToken cancelacionToken)
    {
        var nuevoAlbum = new Album()
        {
            Nombre = album.Nombre,
            FechaSalida = album.FechaSalida,
            Portada = album.Portada,
            AlbumsArtistas = new List<AlbumArtista>(),
            AlbumsGeneros = new List<AlbumGenero>()
        };
        await _contexto.Albums.AddAsync(nuevoAlbum, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return nuevoAlbum.Slug;
    }

    [HttpPut("{slug}")]
    public async Task<BuscarAlbumsDto> ModificarAlbum([FromBody] ModificarAlbumDto albumDto,
        CancellationToken cancelacionToken)
    {
        var album = await _contexto.Albums
            .FirstOrDefaultAsync(x => x.Slug == albumDto.Slug, cancelacionToken);

        if (album == null)
            return new BuscarAlbumsDto();

        await _contexto.SaveChangesAsync(cancelacionToken);

        return album.ConvertirDto();
    }

    [HttpPatch("{slug}")]
    public async Task<bool> CambiarHabilitado([FromBody] HabilitadoAlbumsDto album,
        CancellationToken cancelacionToken)
    {
        var entidad = await _contexto.Albums.FirstOrDefaultAsync(x => x.Slug == album.Slug, cancelacionToken);

        if (entidad == null)
            return false;

        entidad.Habilitado = album.Habilitado;

        await _contexto.SaveChangesAsync(cancelacionToken);

        return true;
    }
}

