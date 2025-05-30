namespace Api.Comun.Modelos.Seguimiento
{
    public class BuscarSeguimientoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string ObjetivoTipo { get; set; }
        public int IdObjetivo { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
