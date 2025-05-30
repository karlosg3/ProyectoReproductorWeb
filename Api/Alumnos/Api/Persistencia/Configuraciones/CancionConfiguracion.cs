using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class CancionConfiguracion
    {
        public void Configure(EntityTypeBuilder<Cancion> constructor)
        {
            constructor.HasKey(a => a.Id);

            constructor
                .HasOne(c => c.Album)
                .WithMany(a => a.Canciones)
                .HasForeignKey(c => c.IdAlbum);

            constructor
                .HasOne(c => c.Artista)
                .WithMany(ar => ar.Canciones)
                .HasForeignKey(c => c.IdArtista);
        }

    }
}
