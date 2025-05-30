using Api.Comun.Interfaces;

namespace Api.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public string Contrasena { get; set; }
    public string FotoPerfil { get; set; }
    public string Rol { get; set; }
    public DateTime FechaRegistro { get; set; }

    public ICollection<Playlist> Playlists { get; set; }
    public ICollection<HistorialReproduccion> HistorialReproducciones { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Seguimiento> Seguimientos { get; set; }
}