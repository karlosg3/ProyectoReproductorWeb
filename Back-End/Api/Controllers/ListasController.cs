using Api.Comun.Interfaces;
using Api.Comun.Modelos.Listas;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("listas")]
public class ListasController: ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;
    
    public ListasController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }
    
    [HttpGet]
    public async Task<List<BuscarListasDto>> ObtenerListas(string nombre, bool habilitado)
    {
        var query = _contexto.Listas.Where(x => x.Habilitado == habilitado);

        if (string.IsNullOrEmpty(nombre) == false)
        {
            query = query.Where(x => x.Nombre.Contains(nombre));
        }
        var lista = await query.ToListAsync();
        
        return lista.ConvertAll(x => x.ConvertirDto());
    }
    
    [HttpGet("{slug}")]
    public async Task<BuscarListasDto> ObtenerListas(string slug, CancellationToken cancelacionToken)
    {
        var lista = await _contexto.Listas.FirstOrDefaultAsync(x => x.Slug == slug, cancelacionToken);
        
        if(lista == null)
            return new BuscarListasDto();
        
        return lista.ConvertirDto();
    }

    [HttpPost]
    public async Task<string> CrearLista([FromBody] CrearListaDto lista, CancellationToken cancelacionToken)
    {
        var existeBoard = await _contexto.Boards.AnyAsync(b => b.Id == lista.IdBoard);
        if (!existeBoard)
            return "El Board no existe";
        
        var maxOrden = await _contexto.Listas
            .Where(t => t.Nombre == lista.Nombre)
            .MaxAsync(t => (int?)t.Orden) ?? 0;

        var ordenFinal = lista.Orden ?? maxOrden + 1;
        
        var nuevaLista = new Lista()
        {
            Nombre = lista.Nombre,
            Orden = ordenFinal,
            IdBoard = lista.IdBoard,
            Habilitado = lista.Habilitado,
        };
        await _contexto.Listas.AddAsync(nuevaLista, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return nuevaLista.Slug;
    }

    [HttpPut("{slug}")]
    public async Task<BuscarListasDto> ModificarLista([FromBody] ModificarListaDto listaDto,
        CancellationToken cancelacionToken)
    {
        var lista = await _contexto.Listas
            .FirstOrDefaultAsync(x => x.Slug == listaDto.Slug, cancelacionToken);
        
        var existeBoard = await _contexto.Boards.AnyAsync(b => b.Id == listaDto.IdBoard);
        if (!existeBoard)
            return null;

        if (lista == null)
            return new BuscarListasDto();
        
        lista.Nombre = listaDto.Nombre;
        
        if (lista.IdBoard != listaDto.IdBoard)
        {
            var maxOrden = await _contexto.Listas
                .Where(b => b.IdBoard == listaDto.IdBoard)
                .MaxAsync(t => (int?)t.Orden) ?? 0;

            lista.IdBoard = listaDto.IdBoard;
            lista.Orden = maxOrden + 1;
        }
        
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return lista.ConvertirDto();
    }
    
    [HttpPut("reordenar-listas")]
    public async Task<IActionResult> ReordenarListas([FromBody] List<ReordenarListasDto> listaDtos, CancellationToken cancelacionToken)
    {
        foreach (var dto in listaDtos)
        {
            var lista = await _contexto.Listas.FindAsync(dto.Slug);
            if (lista != null)
            {
                lista.Orden = dto.NuevoOrden;
            }
        }

        await _contexto.SaveChangesAsync(cancelacionToken);
        return Ok();
    }

    [HttpPatch("{slug}")]
    public async Task<bool> CambiarHabilitado([FromBody] HabilitadoListaDto lista,
        CancellationToken cancelacionToken)
    {
        var entidad = await _contexto.Listas.FirstOrDefaultAsync(x => x.Slug == lista.Slug, cancelacionToken);

        if (entidad == null)
            return false;

        entidad.Habilitado = lista.Habilitado;
        
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return true;
    }
}