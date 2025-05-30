using Api.Comun.Interfaces;
using Api.Comun.Modelos.Album;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("Album")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;

    public AlbumController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    // Crear álbum
    [HttpPost]
    public async Task<ActionResult<int>> Crear([FromBody] CrearAlbumsDto dto, CancellationToken cancelacionToken)
    {
        var album = new Album
        {
            Nombre = dto.Nombre,
            FechaSalida = dto.FechaSalida,
            Duracion = dto.Duracion,
            CantidadCanciones = dto.CantidadCanciones,
            Portada = dto.Portada,
            Slug = dto.Nombre.ToLower().Replace(" ", "-"),
            Habilitado = true
        };

        await _contexto.Albums.AddAsync(album, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(album.Id);
    }

    // Modificar álbum
    [HttpPut("{id}")]
    public async Task<IActionResult> Modificar([FromBody] ModificarAlbumDto dto, CancellationToken cancelacionToken)
    {
        var album = await _contexto.Albums.FirstOrDefaultAsync(x => x.Id == dto.Id, cancelacionToken);

        if (album == null)
            return NotFound();

        // Puedes actualizar el slug si quieres, según tus reglas
        album.Slug = dto.Descripcion.ToLower().Replace(" ", "-");

        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(dto);
    }

    // Habilitar/deshabilitar álbum
    [HttpPatch("{id}/habilitar")]
    public async Task<IActionResult> Habilitar([FromBody] HabilitadoAlbumsDto dto, CancellationToken cancelacionToken)
    {
        var album = await _contexto.Albums.FirstOrDefaultAsync(x => x.Id == dto.Id, cancelacionToken);

        if (album == null)
            return NotFound();

        album.Habilitado = dto.Habilitado;
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok();
    }

    // Consultar álbum por id
    [HttpGet("{id}")]
    public async Task<ActionResult<BuscarAlbumsDto>> Buscar(int id, CancellationToken cancelacionToken)
    {
        var album = await _contexto.Albums.FirstOrDefaultAsync(x => x.Id == id, cancelacionToken);

        if (album == null)
            return NotFound();

        return Ok(album.ConvertirDto());
    }

    // Consultar todos los álbumes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BuscarAlbumsDto>>> BuscarTodos(CancellationToken cancelacionToken)
    {
        var lista = await _contexto.Albums.ToListAsync(cancelacionToken);
        return Ok(lista.ConvertAll(x => x.ConvertirDto()));
    }
}
