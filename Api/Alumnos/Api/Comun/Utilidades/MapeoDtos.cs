using Api.Comun.Modelos.Album;
using Api.Comun.Modelos.Cancion;
using Api.Comun.Modelos.Usuarios;
using Api.Comun.Modelos.Artista;
using Api.Comun.Modelos.Playlist;
using Api.Entidades;

namespace Api.Comun.Utilidades;

public static class MapeoDtos
{

    //USUARIOS
    public static BuscarUsuariosDto ConvertirDto(this Usuario usuario)
    {
        return new BuscarUsuariosDto()
        {
            Slug = usuario.Slug,
            Nombre = usuario.Nombre,
            Habilitado = usuario.Habilitado,
        };
    }

    //ALBUMS
    public static BuscarAlbumsDto ConvertirDto(this Album album)
    {
        return new BuscarAlbumsDto()
        {
            Slug = album.Slug,
            Nombre = album.Nombre,
            Habilitado = album.Habilitado
        };
    }

    //CANCIONES
    public static BuscarCancionDto ConvertirDto(this Cancion cancion)
    {
        return new BuscarCancionDto()
        {
            Slug = cancion.Slug,
            Titulo = cancion.Titulo,
        };
    }

    //ARTISTAS
    public static BuscarArtistaDto ConvertirDto(this Artista artista)
    {
        return new BuscarArtistaDto()
        {
            Slug = artista.Slug,
            Nombre = artista.Nombre
        };


    }

    //PLAYLISTS
    public static BuscarPlaylistDto ConvertirDto(this Playlist playlist)
    {
        return new BuscarPlaylistDto()
        {
            Slug = playlist.Slug,
            Nombre = playlist.Nombre
        };
    }

    //CANCIONESPLAYLIST

    //GENEROS

    //SESIONES USUARIO

}