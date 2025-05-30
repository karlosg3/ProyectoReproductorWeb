namespace Api.Entidades
{
    public class Album
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Duracion { get; set; }
        public int CantidadCanciones { get; set; }
        public string Portada { get; set; }

        public String Slug {  get; set; }
        public Boolean Habilitado { get; set; }

        public ICollection<Cancion> Canciones { get; set; }
        public ICollection<Artista> Artistas { get; set; }
        public ICollection<Genero> Generos { get; set; }
    }
}
