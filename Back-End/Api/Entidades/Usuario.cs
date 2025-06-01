using Api.Comun.Interfaces;

namespace Api.Entidades;

public class Usuario : ISlug
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string CorreoElectronico  { get; set; }
    public string Contraseña { get; set; }
    public bool Habilitado { get; set; }
    public string Slug { get; set; }
    
    public virtual ICollection<SesionUsuario> Sesiones  { get; set; }
    public virtual ICollection<UsuarioTarjeta> UsuarioTarjetas  { get; set; }

    public string ObtenerDescripcionParaSlug()
    {
        return $"{Nombre}";
    }
}
