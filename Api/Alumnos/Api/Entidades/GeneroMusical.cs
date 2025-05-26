using Api.Comun.Interfaces;

namespace Api.Entidades
{
    public class GeneroMusical
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty; /*Para que no sea null*/

        public string Slug { get; set; }

    }
}