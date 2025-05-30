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
                .HasMany(a => a.Artistas)
                .WithMany(ar => ar.Albums)
                .UsingEntity(j => j.ToTable("AlbumArtistas"));

            constructor
                .HasMany(a => a.Generos)
                .WithMany(g => g.Albums)
                .UsingEntity(j => j.ToTable("AlbumGeneros"));
        }
    }
}
