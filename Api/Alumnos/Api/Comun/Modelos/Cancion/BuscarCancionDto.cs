namespace Api.Comun.Modelos.Cancion
{
    public class BuscarCancionDto
    {

        public string Slug { get; set; }
        public string Titulo { get; set; }
        public string Artista { get; set; }

        public bool Habilitado { get; set; }
    }
}
