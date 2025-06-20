﻿namespace Api.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Slug { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<AlbumGenero> AlbumGeneros { get; set; }
    }
}
