using Api.Comun.Interfaces;
using Api.Comun.Modelos.Like;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

// [Authorize]
[Route("Like")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;

    public LikeController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    // Agregar un Like
    [HttpPost]
    public async Task<ActionResult<int>> AgregarLike([FromBody] AgregarLikeDto dto, CancellationToken cancelacionToken)
    {
        var nuevoLike = new Like
        {
            UsuarioId = dto.UsuarioId,
            CancionId = dto.CancionId,
            Habilitado = true
        };

        await _contexto.Likes.AddAsync(nuevoLike, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(nuevoLike.IdLike);
    }

    // Buscar un Like por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Like>> ObtenerLike(int id, CancellationToken cancelacionToken)
    {
        var like = await _contexto.Likes
            .FirstOrDefaultAsync(l => l.IdLike == id, cancelacionToken);

        if (like == null)
            return NotFound();

        return Ok(like);
    }

    // Habilitar un Like (activar nuevamente si estaba desactivado)
    [HttpPut("habilitar/{id}")]
    public async Task<IActionResult> HabilitarLike(int id, CancellationToken cancelacionToken)
    {
        var like = await _contexto.Likes.FirstOrDefaultAsync(l => l.IdLike == id, cancelacionToken);

        if (like == null)
            return NotFound();

        like.Habilitado = true;
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok("Like habilitado correctamente.");
    }
}