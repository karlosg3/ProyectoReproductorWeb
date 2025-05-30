namespace Api.Entidades
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }

        public String Slug { get; set; }
        public Boolean Habilitado { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<Colaboracion> Colaboraciones { get; set; }
    }
}
