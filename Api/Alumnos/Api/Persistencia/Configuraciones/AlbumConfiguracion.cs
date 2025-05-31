using System.Reflection;
using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class AlbumConfiguracion
    {
        public void Configure(EntityTypeBuilder<Album> constructor)
        {
            constructor.HasKey(a => a.Id);

            constructor
                .HasOne(a => a.Artista)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.IdArtista);

            constructor
                .HasOne(a => a.Genero)
                .WithMany(g => g.Albums)
                .HasForeignKey(a => a.IdGenero);
        }
    }
}
