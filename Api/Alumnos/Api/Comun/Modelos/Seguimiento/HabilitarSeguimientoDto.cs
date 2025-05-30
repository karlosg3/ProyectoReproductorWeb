namespace Api.Comun.Modelos.Seguimiento
{
    public class HabilitarSeguimientoDto
    {
        public int Id { get; set; }         // Id del seguimiento
        public bool Habilitado { get; set; } // true: habilitar, false: deshabilitar
    }
}
