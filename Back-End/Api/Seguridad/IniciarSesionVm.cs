namespace Api.Seguridad;

public class IniciarSesionVm
{
    public string Nombre { get; set; }
    public string Contrasena { get; set; }
    public bool MantenerSesion { get; set; }
}