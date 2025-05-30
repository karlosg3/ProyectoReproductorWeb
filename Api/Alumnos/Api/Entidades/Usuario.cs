using System.ComponentModel.DataAnnotations;
using Api.Comun.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Entidades;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Correo { get; set; }
    [Required]
    public string Contrasena { get; set; }
    [Required]
    public string FotoPerfil { get; set; }
    [Required]
    public int Rol { get; set; }
    [Required]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public string Slug { get; set; }
    [Required]
    public bool Habilitado { get; set; } = true;

    //Relacion con Playlist
    public ICollection<Playlist> Playlists { get; set; }

    //Relacion con SesionUsuario
    public ICollection<SesionUsuario> SesionesUsuarios { get; set; }

    public string ObtenerDescripcionParaSlug()
    {
        return $"{Nombre}";
    }

}