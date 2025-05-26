namespace Api.Entidades
{
    public class Colaboracion
    {
        public int idCancion { get; set; }
        public Cancion Cancion { get; set; }

        public int idArtista { get; set; }
        public Artista Artista { get; set; }
    }
}