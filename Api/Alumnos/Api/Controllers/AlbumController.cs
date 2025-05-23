using Api.Comun.Interfaces;
using Api.Comun.Modelos.Album;
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
            Artista = album.Artista,
            FechaSalida = album.FechaSalida,
            Genero = album.Genero,
            Portada = album.Portada,
        };
        await _contexto.Albums.AddAsync(nuevoAlbum, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return nuevoAlbum.Slug;
    }

    [HttpPut("{slug}")]
    public async Task<BuscarAlbumsDto> ModificarAlbum([FromBody] ModificarUsuarioDto usuarioDto,
        CancellationToken cancelacionToken)
    {
        var usuario = await _contexto.Usuarios
            .FirstOrDefaultAsync(x => x.Slug == usuarioDto.Slug, cancelacionToken);

        if (usuario == null)
            return new BuscarUsuariosDto();

        usuario.Nombre = usuarioDto.Nombre;
        usuario.ApellidoPaterno = usuarioDto.ApellidoPaterno;
        usuario.ApellidoMaterno = usuarioDto.ApellidoMaterno;
        usuario.NombreUsuario = usuarioDto.NombreUsuario;

        if (string.IsNullOrEmpty(usuario.Contraseña) == false)
        {
            usuario.Contraseña = _hasherServicio.GenerarHash(usuarioDto.Contraseña);
        }

        await _contexto.SaveChangesAsync(cancelacionToken);

        return usuario.ConvertirDto();
    }
}

