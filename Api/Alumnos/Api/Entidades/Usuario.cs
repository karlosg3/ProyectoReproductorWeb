using Api.Comun.Interfaces;

namespace Api.Entidades;

public class Usuario : ISlug
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public string Contrasena { get; set; }
    public string FotoPerfil { get; set; }
    public string Rol { get; set; }
    public DateTime FechaRegistro { get; set; }
    public String Slug { get; set; }
    public ICollection<HistorialReproduccion> HistorialReproducciones { get; set; }
    public ICollection<Like> Likes { get; set; }
    public Boolean Habilitado { get; set; } = true;

    //Relacion con Playlists
    public int PlaylistId { get; set; }
    public ICollection<Playlist> Playlists { get; set; }

    //Relación con Seguimiento
    public int SeguimientoId { get; set; }
    public ICollection<Seguimiento> Seguimientos { get; set; }


    // Relación con SesionUsuario
    public ICollection<SesionUsuario> SesionesUsuarios { get; set; } = new List<SesionUsuario>();
    public int SesionId { get; set; }

    public string ObtenerDescripcionParaSlug()
    {
        return $"{Nombre}";
    }
}