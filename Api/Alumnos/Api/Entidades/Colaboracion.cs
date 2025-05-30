namespace Api.Entidades
{
    public class Colaboracion
    {
        public int CancionId { get; set; }
        public Cancion Cancion { get; set; }

        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }

        public string Rol { get; set; } // "principal", "invitado", "productor"
    }
}