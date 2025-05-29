using Api.Comun.Modelos.Album;
using Api.Comun.Modelos.Cancion;
using Api.Comun.Modelos.Usuarios;
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
            ApellidoPaterno = usuario.ApellidoPaterno,
            ApellidoMaterno = usuario.ApellidoMaterno,
            NombreUsuario = usuario.NombreUsuario,
            Habilitado = usuario.Habilitado,
        };
    }

    public static BuscarAlbumsDto ConvertirDto(this Album album) {
        return new BuscarAlbumsDto()
        {
            Slug = album.Slug,
            Nombre = album.Nombre,
        };


    }

    public static BuscarCancionDto ConvertirDto(this Cancion cancion)
    {
        return new BuscarCancionDto()
        {
            Slug = cancion.Slug,
            Titulo = cancion.Titulo,
        };


    }
}