using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class AlbumArtistaConfiguracion : IEntityTypeConfiguration<AlbumArtista>
    {
        public void Configure(EntityTypeBuilder<AlbumArtista> builder)
        {
            builder.HasKey(aa => new { aa.AlbumId, aa.ArtistaId });

            builder
                .HasOne(aa => aa.Album)
                .WithMany(a => a.AlbumArtistas)
                .HasForeignKey(aa => aa.AlbumId);

            builder
                .HasOne(aa => aa.Artista)
                .WithMany(a => a.AlbumArtistas)
                .HasForeignKey(aa => aa.ArtistaId);
        }
    }
}
