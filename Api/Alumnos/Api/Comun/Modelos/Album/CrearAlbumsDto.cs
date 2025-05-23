namespace Api.Comun.Modelos.Album
{
    public class CrearAlbumsDto
    {
        public string Slug { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Artista { get; set; }
        public int Genero { get; set; }
        public string Portada { get; set; }
        public bool Habilitado { get; set; }
    }
}
