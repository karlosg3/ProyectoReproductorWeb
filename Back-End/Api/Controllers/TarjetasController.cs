using Api.Comun.Interfaces;
using Api.Comun.Modelos.Tarjetas;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("tarjetas")]
public class TarjetasController: ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;
    
    public TarjetasController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }
    
    [HttpGet]
    public async Task<List<BuscarTarjetasDto>> ObtenerTarjetas(string nombre, bool habilitado)
    {
        var query = _contexto.Tarjetas.Where(x => x.Habilitado == habilitado);

        if (string.IsNullOrEmpty(nombre) == false)
        {
            query = query.Where(x => x.Nombre.Contains(nombre));
        }
        var lista = await query.ToListAsync();
        
        return lista.ConvertAll(x => x.ConvertirDto());
    }
    
    [HttpGet("{slug}")]
    public async Task<BuscarTarjetasDto> ObtenerTarjetas(string slug, CancellationToken cancelacionToken)
    {
        var tarjeta = await _contexto.Tarjetas.FirstOrDefaultAsync(x => x.Slug == slug, cancelacionToken);
        
        if(tarjeta == null)
            return new BuscarTarjetasDto();
        
        return tarjeta.ConvertirDto();
    }

    [HttpPost]
    public async Task<string> CrearTarjeta([FromBody] CrearTarjetaDto tarjeta, CancellationToken cancelacionToken)
    {
        var existeLista = await _contexto.Listas.AnyAsync(l => l.Id == tarjeta.IdLista);
        if (!existeLista)
            return "La lista especificada no existe.";
        
        var maxOrden = await _contexto.Tarjetas
            .Where(t => t.Nombre == tarjeta.Nombre)
            .MaxAsync(t => (int?)t.Orden) ?? 0;

        var ordenFinal = tarjeta.Orden ?? maxOrden + 1;
        
        var nuevaTarjeta = new Tarjeta()
        {
            Nombre = tarjeta.Nombre,
            TipoCredito = tarjeta.TipoCredito,
            TasaInteres = tarjeta.TasaInteres,
            CantidadCredito = tarjeta.CantidadCredito,
            Descripcion = tarjeta.Descripcion,
            Orden = ordenFinal,
            IdLista = tarjeta.IdLista,
            Habilitado = tarjeta.Habilitado,
        };
        await _contexto.Tarjetas.AddAsync(nuevaTarjeta, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return nuevaTarjeta.Slug;
    }

    [HttpPut("{slug}")]
    public async Task<BuscarTarjetasDto> ModificarTarjeta([FromBody] ModificarTarjetaDto tarjetaDto,
        CancellationToken cancelacionToken)
    {
        var tarjeta = await _contexto.Tarjetas
            .FirstOrDefaultAsync(x => x.Slug == tarjetaDto.Slug, cancelacionToken);
        
        var existeLista = await _contexto.Listas.AnyAsync(l => l.Id == tarjetaDto.IdLista);
        if (!existeLista)
            return null;

        if (tarjeta == null)
            return new BuscarTarjetasDto();
        
        tarjeta.Nombre = tarjetaDto.Nombre;
        tarjeta.TipoCredito = tarjetaDto.TipoCredito;
        tarjeta.TasaInteres = tarjetaDto.TasaInteres;
        tarjeta.CantidadCredito = tarjetaDto.CantidadCredito;
        tarjeta.TipoCredito = tarjetaDto.TipoCredito;
        tarjeta.Descripcion = tarjetaDto.Descripcion;
        
        if (tarjeta.IdLista != tarjetaDto.IdLista)
        {
            // Cambiar lista y asignar nuevo orden al final
            var maxOrden = await _contexto.Tarjetas
                .Where(t => t.IdLista == tarjetaDto.IdLista)
                .MaxAsync(t => (int?)t.Orden) ?? 0;

            tarjeta.IdLista = tarjetaDto.IdLista;
            tarjeta.Orden = maxOrden + 1;
        }
        
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return tarjeta.ConvertirDto();
    }
    
    [HttpPut("reordenar-tarjetas")]
    public async Task<IActionResult> ReordenarTarjetas([FromBody] List<ReordenarTarjetasDto> tarjetaDtos, CancellationToken cancelacionToken)
    {
        foreach (var dto in tarjetaDtos)
        {
            var lista = await _contexto.Tarjetas.FindAsync(dto.Slug);
            if (lista != null)
            {
                lista.Orden = dto.NuevoOrden;
            }
        }

        await _contexto.SaveChangesAsync(cancelacionToken);
        return Ok();
    }

    [HttpPatch("{slug}")]
    public async Task<bool> CambiarHabilitado([FromBody] HabilitadoTarjetaDto tarjeta,
        CancellationToken cancelacionToken)
    {
        var entidad = await _contexto.Tarjetas.FirstOrDefaultAsync(x => x.Slug == tarjeta.Slug, cancelacionToken);

        if (entidad == null)
            return false;

        entidad.Habilitado = tarjeta.Habilitado;
        
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return true;
    }
}