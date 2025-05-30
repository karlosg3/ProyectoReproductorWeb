using Api.Comun.Interfaces;

namespace Api.Entidades
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public string ArchivoAudio { get; set; }
        public int NumeroPista { get; set; }
        public int Reproducciones { get; set; }
        public DateTime FechaLanzamiento { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public string Slug { get; set; }
        public bool Habilitado { get; set; }

        public ICollection<Colaboracion> Colaboraciones { get; set; }
        public ICollection<CancionPlaylist> CancionPlaylists { get; set; }
        public ICollection<HistorialReproduccion> HistorialReproducciones { get; set; }
    }
}
