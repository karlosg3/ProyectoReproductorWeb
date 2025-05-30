using Api.Comun.Interfaces;
using Api.Comun.Modelos.Seguimiento;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

// [Authorize]
[Route("seguimiento")]
[ApiController]
public class SeguimientoController : ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;

    public SeguimientoController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    // POST: Agregar seguimiento
    [HttpPost]
    public async Task<ActionResult<int>> AgregarSeguimiento([FromBody] CrearSeguimientoDto dto, CancellationToken cancelacionToken)
    {
        var seguimiento = new Seguimiento(dto.ObjetivoTipo, dto.IdObjetivo)
        {
            UsuarioId = dto.UsuarioId,
            ObjetivoTipo = dto.ObjetivoTipo,
            ObjetivoId = dto.IdObjetivo,
            Activo = true
        };

        await _contexto.Seguimientos.AddAsync(seguimiento, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok(seguimiento.UsuarioId);
    }

    // GET: Buscar seguimiento por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<BuscarSeguimientoDto>> BuscarSeguimiento(int id, CancellationToken cancelacionToken)
    {
        var seguimiento = await _contexto.Seguimientos
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x => x.UsuarioId == id, cancelacionToken);

        if (seguimiento == null)
            return NotFound();

        return Ok(new BuscarSeguimientoDto
        {
            Id = seguimiento.IdSeguimiento,
            UsuarioId = seguimiento.UsuarioId,
            Activo = seguimiento.Activo
        });
    }

    // PATCH: Habilitar o deshabilitar seguimiento
    [HttpPatch("{id}")]
    public async Task<IActionResult> HabilitarSeguimiento(int id, [FromBody] HabilitarSeguimientoDto dto,
        CancellationToken cancelacionToken)
    {
        var seguimiento = await _contexto.Seguimientos.FirstOrDefaultAsync(x => x.IdSeguimiento == id, cancelacionToken);

        if (seguimiento == null)
            return NotFound();

        seguimiento.Activo = dto.Habilitado;
        await _contexto.SaveChangesAsync(cancelacionToken);

        return Ok("Seguimiento actualizado correctamente.");
    }
}