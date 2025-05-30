namespace Api.Comun.Modelos.Colaboracion
{
    public class AgregarColaboracionDto
    {
        public int CancionId { get; set; }
        public int ArtistaId { get; set; }
        public string Rol { get; set; }  // Por ejemplo: principal, invitado, productor
    }
}
