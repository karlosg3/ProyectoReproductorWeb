using Api.Comun.Interfaces;

namespace Api.Entidades
{
    public class Cancion : ISlug
    {

        public int Id {  get; set; }

        public string Titulo { get; set; }

        public string ArchivoDeAudio { get; set; }

        public int IdAlbum { get; set; }

        public int IdArtista { get; set; }

        public int NumeroDePista { get; set; }

        public long Reproducciones { get; set; }

        public DateOnly FechaDeLanzamiento { get; set; }

        public List<Artista> Artistas { get; set; }

        public string Slug { get; set; }


        public string ObtenerDescripcionParaSlug()
        {
            return $"{Titulo}";
        }






    }
}
