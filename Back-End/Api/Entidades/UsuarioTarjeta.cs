namespace Api.Entidades;

public class UsuarioTarjeta
{ 
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }

    public int IdTarjeta { get; set; }
    public Tarjeta Tarjeta { get; set; }
}