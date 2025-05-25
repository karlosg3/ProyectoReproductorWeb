using Api.Comun.Modelos.AlbumGenero;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class AlbumGeneroConfiguracion : IEntityTypeConfiguration<AlbumGenero>
    {
        public void Configure(EntityTypeBuilder<AlbumGenero> builder)
        {
            builder.HasKey(ag => new { ag.AlbumId, ag.GeneroId });

            builder
                .HasOne(ag => ag.Album)
                .WithMany(a => a.AlbumGeneros)
                .HasForeignKey(ag => ag.AlbumId);

            builder
                .HasOne(ag => ag.Genero)
                .WithMany(g => g.AlbumGeneros)
                .HasForeignKey(ag => ag.GeneroId);
        }
    }
}
