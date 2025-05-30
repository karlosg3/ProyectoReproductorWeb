﻿namespace Api.Comun.Modelos.Artista
{
    public class BuscarArtistaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }
        public string Slug { get; set; }
        public bool Habilitado { get; set; }
    }
}
