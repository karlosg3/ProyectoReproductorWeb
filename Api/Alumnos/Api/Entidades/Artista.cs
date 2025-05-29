namespace Api.Entidades
{
    public class Artista
    {
        public int IdArtista { get; set; }           
        public string Nombre { get; set; }           
        public string? Imagen { get; set; }         
        public string? Descripcion { get; set; }

        public ICollection<Cancion> Canciones { get; set; }


        public ICollection<Album>? Albums { get; set; }      

        //public ICollection<Cancion>? Canciones { get; set; } 

        public ICollection<Colaboracion>? Colaboraciones { get; set; } 
    }
}
