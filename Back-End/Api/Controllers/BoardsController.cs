using Api.Comun.Interfaces;
using Api.Comun.Modelos.Boards;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/boards")]
public class BoardsController: ControllerBase
{
    private readonly IAplicacionBdContexto _contexto;
    
    public BoardsController(IAplicacionBdContexto contexto)
    {
        _contexto = contexto;
    }
    
    [HttpGet]
    public async Task<List<BuscarBoardsDto>> ObtenerBoards(string nombre, bool habilitado)
    {
        var query = _contexto.Boards.Where(x => x.Habilitado == habilitado);

        if (string.IsNullOrEmpty(nombre) == false)
        {
            query = query.Where(x => x.Nombre.Contains(nombre));
        }
        var lista = await query.ToListAsync();
        
        return lista.ConvertAll(x => x.ConvertirDto());
    }
    
    [HttpGet("{slug}")]
    public async Task<BuscarBoardsDto> ObtenerBoards(string slug, CancellationToken cancelacionToken)
    {
        var lista = await _contexto.Boards.FirstOrDefaultAsync(x => x.Slug == slug, cancelacionToken);
        
        if(lista == null)
            return new BuscarBoardsDto();
        
        return lista.ConvertirDto();
    }

    [HttpPost]
    public async Task<string> CrearBoard([FromBody] CrearBoardDto board, CancellationToken cancelacionToken)
    {
        var nuevoBoard = new Board()
        {
            Nombre = board.Nombre,
            Habilitado = board.Habilitado,
        };
        await _contexto.Boards.AddAsync(nuevoBoard, cancelacionToken);
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return nuevoBoard.Slug;
    }

    [HttpPut("{slug}")]
    public async Task<BuscarBoardsDto> ModificarBoard([FromBody] ModificarBoardDto boardDto,
        CancellationToken cancelacionToken)
    {
        var lista = await _contexto.Boards
            .FirstOrDefaultAsync(x => x.Slug == boardDto.Slug, cancelacionToken);
        
        if (lista == null)
            return new BuscarBoardsDto();
        
        lista.Nombre = boardDto.Nombre;
        
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return lista.ConvertirDto();
    }

    [HttpPatch("{slug}")]
    public async Task<bool> CambiarHabilitado([FromBody] HabilitadoBoardDto board,
        CancellationToken cancelacionToken)
    {
        var entidad = await _contexto.Boards.FirstOrDefaultAsync(x => x.Slug == board.Slug, cancelacionToken);

        if (entidad == null)
            return false;

        entidad.Habilitado = board.Habilitado;
        
        await _contexto.SaveChangesAsync(cancelacionToken);
        
        return true;
    }

    [HttpDelete]
    public async Task<bool> EliminarBoard(string slug, CancellationToken cancelacionToken)
    {
        var board = await _contexto.Boards.FirstOrDefaultAsync(x => x.Slug == slug, cancelacionToken);
        if (board == null)
            return false;
        
        _contexto.Boards.Remove(board);
        await _contexto.SaveChangesAsync(cancelacionToken);
        return true;
    }
}