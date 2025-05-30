using Api.Entidades;

namespace Api.Comun.Modelos.Cancion
{
    public class CrearCancionDto
    {


        public string Titulo { get; set; }

        public string ArchivoDeAudio { get; set; }

        public int IdAlbum { get; set; }

        public int IdArtista { get; set; }

        public string Portada { get; set; }

        public DateOnly FechaDeLanzamiento { get; set; }

        public bool Habilitado { get; set; }

        public int NumeroPista { get; set; }

    }
}
