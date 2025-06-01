using Api.Comun.Modelos.Usuarios;
using Api.Comun.Modelos.Listas;
using Api.Comun.Modelos.Tarjetas;
using Api.Comun.Modelos.Boards;
using Api.Entidades;

namespace Api.Comun.Utilidades;

public static class MapeoDtos
{
    public static BuscarUsuariosDto ConvertirDto(this Usuario usuario)
    {
        return new BuscarUsuariosDto()
        {
            Slug = usuario.Slug,
            Nombre = usuario.Nombre,
            CorreoElectronico = usuario.CorreoElectronico,
            Habilitado = usuario.Habilitado,
        };
    }
    
    public static BuscarTarjetasDto ConvertirDto(this Tarjeta tarjeta)
    {
        return new BuscarTarjetasDto()
        {
            Slug = tarjeta.Slug,
            Nombre = tarjeta.Nombre,
            TipoCredito = tarjeta.TipoCredito,
            TasaInteres = tarjeta.TasaInteres,
            CantidadCredito = tarjeta.CantidadCredito,
            Descripcion = tarjeta.Descripcion,
            Habilitado = tarjeta.Habilitado,
        };
    }
    
    public static BuscarListasDto ConvertirDto(this Lista lista)
    {
        return new BuscarListasDto()
        {
            Slug = lista.Slug,
            Nombre = lista.Nombre,
            Habilitado = lista.Habilitado,
        };
    }
    
    public static BuscarBoardsDto ConvertirDto(this Board board)
    {
        return new BuscarBoardsDto()
        {
            Slug = board.Slug,
            Nombre = board.Nombre,
            Habilitado = board.Habilitado,
        };
    }
}