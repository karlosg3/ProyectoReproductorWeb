using Api.Comun.Interfaces;
using Api.Comun.Modelos.UsuarioTarjetas;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("usuarioTarjetas")]
public class UsuarioTarjetasController: ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;
    
    public UsuarioTarjetasController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }

    [HttpPost]
    public async Task<string> AsignarTarjeta([FromBody] CrearUsuarioTarjetaDto asignacion, CancellationToken cancelacionToken)
    {
        
        var nuevaAsignacion = new UsuarioTarjeta()
        {
            UsuarioId = asignacion.UsuarioId,
            TarjetaId = asignacion.TarjetaId,
        };
        await _contexto.UsuarioTarjetas.AddAsync(nuevaAsignacion, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return nuevaAsignacion.UsuarioId +  " asignado a " + nuevaAsignacion.TarjetaId;
    }
    
    [HttpDelete]
    public async Task<IActionResult> EliminarAsignacion([FromQuery] int usuarioId, [FromQuery] int tarjetaId, CancellationToken cancelacionToken)
    {
        var asignacion = await _contexto.UsuarioTarjetas
            .FirstOrDefaultAsync(ut => ut.UsuarioId == usuarioId && ut.TarjetaId == tarjetaId);

        if (asignacion == null)
            return NotFound();

        _contexto.UsuarioTarjetas.Remove(asignacion);
        await _contexto.SaveChangesAsync(cancelacionToken);

        return NoContent();
    }
}